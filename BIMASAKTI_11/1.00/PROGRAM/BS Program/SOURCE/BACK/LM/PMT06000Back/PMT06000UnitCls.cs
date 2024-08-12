﻿using System.Data;
using System.Data.Common;
using System.Diagnostics;
using PMT06000Common;
using PMT06000Common.DTOs;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;

namespace PMT06000Back;

public class PMT06000UnitCls : R_BusinessObject<PMT06000OvtUnitDTO>
{
    private LoggerPMT06000 _logger;
    private readonly ActivitySource _activitySource;

    public PMT06000UnitCls()
    {
        _logger = LoggerPMT06000.R_GetInstanceLogger();
        _activitySource = PMT06000Activity.R_GetInstanceActivitySource();
    }

    protected override PMT06000OvtUnitDTO R_Display(PMT06000OvtUnitDTO poEntity)
    {
        using var loActivity = _activitySource.StartActivity(nameof(R_Display));
        R_Exception loEx = new();
        PMT06000OvtUnitDTO loRtn = null;
        R_Db loDb;
        DbConnection loConn;
        DbCommand loCmd;
        string lcQuery;
        try
        {
            loDb = new R_Db();
            loConn = loDb.GetConnection();
            loCmd = loDb.GetCommand();

            lcQuery = "RSP_PM_GET_OVT_UNIT_DETAIL";
            loCmd.CommandType = CommandType.StoredProcedure;
            loCmd.CommandText = lcQuery;

            loDb.R_AddCommandParameter(loCmd, "@CREC_ID", DbType.String, 50, poEntity.CREC_ID);

            var loDbParam = loCmd.Parameters.Cast<DbParameter>()
                .Where(x =>
                    x.ParameterName is
                        "@CREC_ID"
                )
                .Select(x => x.Value);
            
            _logger.LogDebug("EXEC {pcQuery} {@poParam}", lcQuery, loDbParam);
            
            var loDataTable = loDb.SqlExecQuery(loConn, loCmd, true);

            loRtn = R_Utility.R_ConvertTo<PMT06000OvtUnitDTO>(loDataTable).FirstOrDefault();
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
            _logger.LogError(loEx);
        }

        EndBlock:
        loEx.ThrowExceptionIfErrors();

        return loRtn;
    }

    protected override void R_Saving(PMT06000OvtUnitDTO poNewEntity, eCRUDMode poCRUDMode)
    {
        using var loActivity = _activitySource.StartActivity(nameof(R_Saving));
        R_Exception loEx = new();
        string lcQuery;
        R_Db loDb;
        DbCommand loCmd;
        DbConnection loConn = null;
        PMT06000OvtUnitDTO loResult = null;
        
        try
        {
            loDb = new R_Db();
            loConn = loDb.GetConnection();
            loCmd = loDb.GetCommand();
            
            R_ExternalException.R_SP_Init_Exception(loConn);

            poNewEntity.CACTION = poCRUDMode == eCRUDMode.AddMode ? "NEW" : "EDIT";
            
            lcQuery = "RSP_PM_SAVE_OVT_UNIT";
            loCmd.CommandType = CommandType.StoredProcedure;
            loCmd.CommandText = lcQuery;

            loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 8, poNewEntity.CCOMPANY_ID);
            loDb.R_AddCommandParameter(loCmd, "@CPROPERTY_ID", DbType.String, 20, poNewEntity.CPROPERTY_ID);
            loDb.R_AddCommandParameter(loCmd, "@CUSER_ID", DbType.String, 8, poNewEntity.CUSER_ID);
            loDb.R_AddCommandParameter(loCmd, "@CACTION", DbType.String, 10, poNewEntity.CACTION);
            loDb.R_AddCommandParameter(loCmd, "@CPARENT_ID", DbType.String, 50, poNewEntity.CPARENT_ID);
            loDb.R_AddCommandParameter(loCmd, "@CREC_ID", DbType.String, 50, poNewEntity.CREC_ID);
            loDb.R_AddCommandParameter(loCmd, "@CREF_NO", DbType.String, 30, poNewEntity.CREF_NO);
            loDb.R_AddCommandParameter(loCmd, "@CDEPT_CODE", DbType.String, 20, poNewEntity.CDEPT_CODE);
            loDb.R_AddCommandParameter(loCmd, "@CTRANS_CODE", DbType.String, 10, poNewEntity.CTRANS_CODE);
            loDb.R_AddCommandParameter(loCmd, "@CSEQ_NO", DbType.String, 3, poNewEntity.CSEQ_NO);
            loDb.R_AddCommandParameter(loCmd, "@CSERVICE_ID", DbType.String, 20, poNewEntity.CSERVICE_ID);
            loDb.R_AddCommandParameter(loCmd, "@CFLOOR_ID", DbType.String, 20, poNewEntity.CFLOOR_ID);
            loDb.R_AddCommandParameter(loCmd, "@CUNIT_ID", DbType.String, 20, poNewEntity.CUNIT_ID);
            
            
            var loDbParam = loCmd.Parameters.Cast<DbParameter>()
                .Where(x =>
                    x.ParameterName is 
                        "@CCOMPANY_ID" or 
                        "@CPROPERTY_ID" or
                        "@CUSER_ID" or
                        "@CACTION" or
                        "@CPARENT_ID" or
                        "@CREC_ID" or
                        "@CREF_NO" or
                        "@CDEPT_CODE" or
                        "@CTRANS_CODE" or
                        "@CSEQ_NO" or
                        "@CSERVICE_ID" or
                        "@CFLOOR_ID" or
                        "@CUNIT_ID"
                )
                .Select(x => x.Value);
            
            _logger.LogDebug("EXEC {pcQuery} {@poParam}", lcQuery, loDbParam);

            try
            {
                var loReturn = loDb.SqlExecQuery(loConn, loCmd, false);
                loResult = R_Utility.R_ConvertTo<PMT06000OvtUnitDTO>(loReturn).FirstOrDefault();
                poNewEntity.CREC_ID = loResult?.CREC_ID;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);            
                _logger.LogError(loEx);
            }

            loEx.Add(R_ExternalException.R_SP_Get_Exception(loConn));
        }
        catch (Exception ex)
        {
            loEx.Add(ex);            
            _logger.LogError(loEx);
        }

        finally
        {
            if (loConn != null)
            {
                if (loConn.State != ConnectionState.Closed)
                {
                    loConn.Close();
                }

                loConn.Dispose();
            }
        }

        EndBlock:
        loEx.ThrowExceptionIfErrors();
    }

    protected override void R_Deleting(PMT06000OvtUnitDTO poEntity)
    {
        using var loActivity = _activitySource.StartActivity(nameof(R_Deleting));
        R_Exception loEx = new();
        string lcQuery;
        R_Db loDb;
        DbCommand loCmd;
        DbConnection loConn = null;
        
        try
        {
            loDb = new R_Db();
            loConn = loDb.GetConnection();
            loCmd = loDb.GetCommand();
            
            R_ExternalException.R_SP_Init_Exception(loConn);

            lcQuery = "RSP_PM_DELETE_OVT";
            loCmd.CommandType = CommandType.StoredProcedure;
            loCmd.CommandText = lcQuery;

            loDb.R_AddCommandParameter(loCmd, "@CCOMPANY_ID", DbType.String, 8, poEntity.CCOMPANY_ID);
            loDb.R_AddCommandParameter(loCmd, "@CUSER_ID", DbType.String, 20, poEntity.CUSER_ID);
            loDb.R_AddCommandParameter(loCmd, "@CREC_ID", DbType.String, 50, poEntity.CREC_ID);
            loDb.R_AddCommandParameter(loCmd, "@CFLAG", DbType.String, 10, poEntity.CFLAG);

            var loDbParam = loCmd.Parameters.Cast<DbParameter>()
                .Where(x =>
                    x.ParameterName is 
                        "@CCOMPANY_ID" or 
                        "@CUSER_ID" or
                        "@CREC_ID" or 
                        "@CFLAG" 
                )
                .Select(x => x.Value);
            
            _logger.LogDebug("EXEC {pcQuery} {@poParam}", lcQuery, loDbParam);
            
            try
            {
                loDb.SqlExecNonQuery(loConn, loCmd, false);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);            
                _logger.LogError(loEx);
            }

            loEx.Add(R_ExternalException.R_SP_Get_Exception(loConn));
        }
        catch (Exception ex)
        {
            loEx.Add(ex);            
            _logger.LogError(loEx);
        }

        finally
        {
            if (loConn != null)
            {
                if (loConn.State != ConnectionState.Closed)
                {
                    loConn.Close();
                }

                loConn.Dispose();
            }
        }

        loEx.ThrowExceptionIfErrors();
    }
}