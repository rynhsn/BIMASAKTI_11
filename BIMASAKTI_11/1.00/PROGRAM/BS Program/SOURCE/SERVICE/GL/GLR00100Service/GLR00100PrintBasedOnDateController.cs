﻿using System.Collections;
using System.Diagnostics;
using System.Globalization;
using BaseHeaderReportCOMMON;
using GLR00100Back;
using GLR00100Common;
using GLR00100Common.DTOs;
using GLR00100Common.DTOs.Print;
using GLR00100Common.Params;
using GLR00100Service.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using R_BackEnd;
using R_Cache;
using R_Common;
using R_CommonFrontBackAPI;
using R_CommonFrontBackAPI.Log;
using R_ReportFastReportBack;

namespace GLR00100Service;

public class GLR00100PrintBasedOnDateController : R_ReportControllerBase
{
    private LoggerGLR00100 _logger;
    private R_ReportFastReportBackClass _ReportCls;
    private GLR00100ReportParam _Parameter;
    private readonly ActivitySource _activitySource;

    public GLR00100PrintBasedOnDateController(ILogger<GLR00100PrintBasedOnDateController> logger)
    {
        LoggerGLR00100.R_InitializeLogger(logger);
        _logger = LoggerGLR00100.R_GetInstanceLogger();
        _activitySource = GLR00100Activity.R_InitializeAndGetActivitySource(nameof(GLR00100PrintBasedOnDateController));

        _ReportCls = new R_ReportFastReportBackClass();
        _ReportCls.R_InstantiateMainReportWithFileName += _ReportCls_R_InstantiateMainReportWithFileName;
        _ReportCls.R_GetMainDataAndName += _ReportCls_R_GetMainDataAndName;
    }

    private void _ReportCls_R_InstantiateMainReportWithFileName(ref string pcfiletemplate)
    {
        pcfiletemplate = Path.Combine("Reports", "GLR00100ActivityReportBasedOnDate.frx");
    }

    private void _ReportCls_R_GetMainDataAndName(ref ArrayList poData, ref string pcDataSourceName)
    {
        poData.Add(GeneratePrint(_Parameter));
        pcDataSourceName = "ResponseDataModel";
    }

    [HttpPost]
    public R_DownloadFileResultDTO ActivityReportBasedOnDatePost(GLR00100ReportParam poParam)
    {
        using var loActivity = _activitySource.StartActivity(nameof(ActivityReportBasedOnDatePost));
        _logger.LogInfo("Start - Post Account Status");
        R_Exception loException = new();
        GLR00100ReportLogKeyDTO loCache = null;
        R_DownloadFileResultDTO loRtn = null;
        try
        {
            loRtn = new R_DownloadFileResultDTO();
            loCache = new GLR00100ReportLogKeyDTO
            {
                poParam = poParam,
                poLogKey = (R_NetCoreLogKeyDTO)R_NetCoreLogAsyncStorage.GetData(R_NetCoreLogConstant.LOG_KEY)
            };


            _logger.LogInfo("Set GUID Param - Post Account Status");
            R_DistributedCache.R_Set(loRtn.GuidResult, R_NetCoreUtility.R_SerializeObjectToByte(loCache));
        }
        catch (Exception ex)
        {
            loException.Add(ex);
            _logger.LogError(loException);
        }

        loException.ThrowExceptionIfErrors();
        _logger.LogInfo("End - Post Account Status");
        return loRtn;
    }

    [HttpGet, AllowAnonymous]
    public FileStreamResult ActivityReportBasedOnDateGet(string pcGuid)
    {
        using var loActivity = _activitySource.StartActivity(nameof(ActivityReportBasedOnDateGet));
        _logger.LogInfo("Start - Get Account Status");
        R_Exception loException = new();
        FileStreamResult loRtn = null;
        GLR00100ReportLogKeyDTO loResultGUID = null;
        try
        {
            //Get Parameter
            loResultGUID =
                R_NetCoreUtility.R_DeserializeObjectFromByte<GLR00100ReportLogKeyDTO>(
                    R_DistributedCache.Cache.Get(pcGuid));

            //Get Data and Set Log Key
            R_NetCoreLogUtility.R_SetNetCoreLogKey(loResultGUID.poLogKey);

            _Parameter = loResultGUID.poParam;
            loRtn = new FileStreamResult(_ReportCls.R_GetStreamReport(), R_ReportUtility.GetMimeType(R_FileType.PDF));
        }
        catch (Exception ex)
        {
            loException.Add(ex);
            _logger.LogError(loException);
        }

        loException.ThrowExceptionIfErrors();
        _logger.LogInfo("End - Get Account Status");
        return loRtn;
    }

    private GLR00100ReportWithBaseHeaderDTO GeneratePrint(GLR00100ReportParam poParam)
    {
        using var loActivity = _activitySource.StartActivity(nameof(GeneratePrint));
        var loEx = new R_Exception();
        var loRtn = new GLR00100ReportWithBaseHeaderDTO();
        var loCultureInfo = new CultureInfo(poParam.CREPORT_CULTURE);

        try
        {
            loRtn.BaseHeaderColumn.Page = R_Utility.R_GetMessage(typeof(BaseHeaderResources.Resources_Dummy_Class),
                "Page", loCultureInfo);
            loRtn.BaseHeaderColumn.Of =
                R_Utility.R_GetMessage(typeof(BaseHeaderResources.Resources_Dummy_Class), "Of", loCultureInfo);
            loRtn.BaseHeaderColumn.Print_Date =
                R_Utility.R_GetMessage(typeof(BaseHeaderResources.Resources_Dummy_Class), "Print_Date", loCultureInfo);
            loRtn.BaseHeaderColumn.Print_By = R_Utility.R_GetMessage(typeof(BaseHeaderResources.Resources_Dummy_Class),
                "Print_By", loCultureInfo);

            var loLabelObject = new GLR00100ReportLabelDTO();
            var loLabel = AssignValuesWithMessages(typeof(GLR00100BackResources.Resources_Dummy_Class),
                loCultureInfo, loLabelObject);

            _logger.LogInfo("Set Base Header Data");

            loRtn.BaseHeaderData = new BaseHeaderDTO
            {
                CCOMPANY_NAME = "PT Realta Chakradarma",
                CPRINT_CODE = "GLR00100",
                CPRINT_NAME = "Activity Report",
                CUSER_ID = poParam.CUSER_ID,
            };

            var loData = new GLR00100ReportResultDTO()
            {
                Title = "Activity Report",
                Label = (GLR00100ReportLabelDTO)loLabel,
                Header = null,
                Data = new List<GLR00100ResultActivityReportDTO>(),
                SubData = new List<GLR00100ResultActivitySubReportDTO>()
            };

            _logger.LogInfo("Set Parameter");
            var loDbParam = new GLR00100ParameterDb
            {
                CCOMPANY_ID = poParam.CCOMPANY_ID,
                CUSER_ID = poParam.CUSER_ID,
                CLANGUAGE_ID = poParam.CLANGUAGE_ID,
                CPERIOD_TYPE = poParam.CPERIOD_TYPE,
                CFROM_DATE = poParam.CFROM_PERIOD,
                CTO_DATE = poParam.CTO_PERIOD,
                CFROM_DEPT_CODE = poParam.CFROM_DEPT_CODE,
                CTO_DEPT_CODE = poParam.CTO_DEPT_CODE,
                CCURRENCY_TYPE = poParam.CCURRENCY_TYPE
            };

            _logger.LogInfo("Get Detail Activity Report");

            var loCls = new GLR00100Cls();
            loData.Data = loCls.BasedOnDateReportDb(loDbParam);

            loData.Header = new GLR00100ReportHeaderBasedOnDateDTO
            {
                CFROM_DEPT_CODE = loData.Data.FirstOrDefault()?.CFROM_DEPT_CODE,
                CTO_DEPT_CODE = loData.Data.FirstOrDefault()?.CTO_DEPT_CODE,
                CFROM_PERIOD = loData.Data.FirstOrDefault()?.CFROM_PERIOD,
                CTO_PERIOD = loData.Data.FirstOrDefault()?.CTO_PERIOD,
                CCURRENCY_TYPE = poParam.CCURRENCY_TYPE,
                CCURRENCY_TYPE_NAME = loData.Data.FirstOrDefault()?.CCURRENCY_TYPE_NAME,
                CREPORT_BASED_ON = poParam.CREPORT_TYPE
            };
            
            //looping dan ubah ref date menjadi dd-MM-yyyy
            foreach (var item in loData.Data)
            {
                item.CREF_DATE_DISPLAY = DateTime.TryParseExact(item.CREF_DATE, "yyyyMMdd",
                    CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var refDate)
                    ? refDate.ToString("dd-MMM-yyyy")
                    : null;
                item.CDOC_DATE_DISPLAY = DateTime.TryParseExact(item.CDOC_DATE, "yyyyMMdd",
                    CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var docDate)
                    ? docDate.ToString("dd-MMM-yyyy")
                    : null;
            }

            loData.SubData = loCls.BasedOnDateSubReportDb(loDbParam);

            loRtn.Data = loData;
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
            _logger.LogError(loEx);
        }

        loEx.ThrowExceptionIfErrors();
        return loRtn;
    }

    private object AssignValuesWithMessages(Type poResourceType, CultureInfo poCultureInfo, object poObject)
    {
        object loObj = Activator.CreateInstance(poObject.GetType());
        var loGetPropertyObject = poObject.GetType().GetProperties();

        foreach (var property in loGetPropertyObject)
        {
            string propertyName = property.Name;
            string message = R_Utility.R_GetMessage(poResourceType, propertyName, poCultureInfo);
            property.SetValue(loObj, message);
        }

        return loObj;
    }
}