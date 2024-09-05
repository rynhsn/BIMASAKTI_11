﻿using GSM02500COMMON;
using GSM02500COMMON.DTOs;
using GSM02500COMMON.DTOs.GSM02530;
using GSM02500COMMON.DTOs.GSM02531;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GSM02500MODEL
{
    public class GSM02540UtilitiesModel : R_BusinessObjectServiceClientBase<GSM02531UtilityParameterDTO>, IGSM02540Utilities
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/GSM02540Utilities";
        private const string DEFAULT_MODULE = "gs";

        public GSM02540UtilitiesModel(string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true) :
            base(pcHttpClientName, pcRequestServiceEndPoint, DEFAULT_MODULE, plSendWithContext, plSendWithToken)
        {
        }

        public TemplateUnitUtilityDTO DownloadTemplateUnitUtility()
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateUnitUtilityDTO> DownloadTemplateUnitUtilityAsync()
        {
            R_Exception loEx = new R_Exception();
            TemplateUnitUtilityDTO loResult = new TemplateUnitUtilityDTO();

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                var loTempResult = await R_HTTPClientWrapper.R_APIRequestObject<TemplateUnitUtilityDTO>(
                    _RequestServiceEndPoint,
                    nameof(IGSM02540Utilities.DownloadTemplateUnitUtility),
                    DEFAULT_MODULE,
                    _SendWithContext,
                    _SendWithToken);

                loResult = loTempResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public IAsyncEnumerable<GSM02531UtilityDTO> GetUtilitiesList()
        {
            throw new NotImplementedException();
        }
        public async Task<GSM02531UtilityResultDTO> GetUtilitiesListStreamAsync()
        {
            R_Exception loEx = new R_Exception();
            List<GSM02531UtilityDTO> loResult = null;
            GSM02531UtilityResultDTO loRtn = new GSM02531UtilityResultDTO();
            //R_ContextHeader loContextHeader = new R_ContextHeader();

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;

                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<GSM02531UtilityDTO>(
                    _RequestServiceEndPoint,
                    nameof(IGSM02540Utilities.GetUtilitiesList),
                    DEFAULT_MODULE,
                    _SendWithContext,
                    _SendWithToken);

                loRtn.Data = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

        EndBlock:
            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        public IAsyncEnumerable<GSM02531UtilityTypeDTO> GetUtilityTypeList()
        {
            throw new NotImplementedException();
        }
        public async Task<GSM02531UtilityTypeResultDTO> GetUtilityTypeListStreamAsync()
        {
            R_Exception loEx = new R_Exception();
            List<GSM02531UtilityTypeDTO> loResult = null;
            GSM02531UtilityTypeResultDTO loRtn = new GSM02531UtilityTypeResultDTO();
            //R_ContextHeader loContextHeader = new R_ContextHeader();

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;

                loResult = await R_HTTPClientWrapper.R_APIRequestStreamingObject<GSM02531UtilityTypeDTO>(
                    _RequestServiceEndPoint,
                    nameof(IGSM02540Utilities.GetUtilityTypeList),
                    DEFAULT_MODULE,
                    _SendWithContext,
                    _SendWithToken);

                loRtn.Data = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

        EndBlock:
            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        public GSM02500ActiveInactiveResultDTO RSP_GS_ACTIVE_INACTIVE_OTHER_UNIT_UTILITIESMethod(GSM02500ActiveInactiveParameterDTO poParam)
        {
            throw new NotImplementedException();
        }
        
        public async Task RSP_GS_ACTIVE_INACTIVE_OTHER_UNIT_UTILITIESMethodAsync(GSM02500ActiveInactiveParameterDTO poParam)
        {
            R_Exception loEx = new R_Exception();
            GSM02500ActiveInactiveResultDTO loRtn = new GSM02500ActiveInactiveResultDTO();

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;

                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<GSM02500ActiveInactiveResultDTO, GSM02500ActiveInactiveParameterDTO> (
                    _RequestServiceEndPoint,
                    nameof(IGSM02540Utilities.RSP_GS_ACTIVE_INACTIVE_OTHER_UNIT_UTILITIESMethod),
                    poParam,
                    DEFAULT_MODULE,
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

        EndBlock:
            loEx.ThrowExceptionIfErrors();
        }
    }
}
