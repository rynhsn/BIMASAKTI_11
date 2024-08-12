﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using TXB00200Common;
using TXB00200Common.DTOs;
using TXB00200Common.Params;

namespace TXB00200Model.ViewModel
{
    public class TXB00200ViewModel : R_ViewModel<TXB00200PropertyDTO>
    {
        private TXB00200Model _model = new TXB00200Model();

        public List<TXB00200PropertyDTO> PropertyList = new List<TXB00200PropertyDTO>();
        public List<TXB00200PeriodDTO> PeriodList = new List<TXB00200PeriodDTO>();
        
        public string SelectedPropertyId { get; set; }
        public int SelectedYear { get; set; }
        public string SelectedPeriodNo { get; set; }

        public async Task GetPropertyList()
        {
            var loEx = new R_Exception();
            try
            {
                var loReturn =
                    await _model.GetAsync<TXB00200ListDTO<TXB00200PropertyDTO>>(
                        nameof(ITXB00200.TXB00200GetPropertyList));
                PropertyList = loReturn.Data;
                SelectedPropertyId = PropertyList[0].CPROPERTY_ID;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        
        public async Task GetPeriodList()
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = new TXB00200YearParam { CYEAR = SelectedYear.ToString() };

                var loReturn =
                    await _model.GetAsync<TXB00200ListDTO<TXB00200PeriodDTO>, TXB00200YearParam>(
                        nameof(ITXB00200.TXB00200GetPeriodList), loParam);
                PeriodList = loReturn.Data;
                SelectedPeriodNo = PeriodList[0].CPERIOD_NO;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        
        
        public async Task ProcessSoftPeriod()
        {
            var loEx = new R_Exception();
            try
            {
                var loParam = new PMB05000PeriodParam
                {
                    CCURRENT_SOFT_PERIOD = SystemParam.ISOFT_PERIOD_YY + SystemParam.CSOFT_PERIOD_MM
                };
                
                var loResult =
                    await _model.GetAsync<PMB05000SingleDTO<PMB05000PeriodParam>, PMB05000PeriodParam>(
                        nameof(IPMB05000.PMB05000UpdateSoftPeriod), loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

    }
}