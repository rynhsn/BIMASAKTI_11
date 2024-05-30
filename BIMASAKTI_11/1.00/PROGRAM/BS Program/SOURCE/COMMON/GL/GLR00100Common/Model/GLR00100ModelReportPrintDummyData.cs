﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BaseHeaderReportCOMMON;
using GLR00100Common.DTOs;
using GLR00100Common.DTOs.Print;

namespace GLR00100Common.Model
{
    public static class GLR00100ModelReportDummyData
    {
        public static GLR00100ReportResultDTO DefaultData()
        {
            var loCollection = new List<GLR00100ResultActivityReportDTO>
            {
                new GLR00100ResultActivityReportDTO
                {
                    CREF_DATE = "20240102",
                    CTRANS_CODE = "190030",
                    CTRANSACTION_NAME = "Wire Transfer Journal",
                    CDEPT_CODE = "ADM",
                    CREF_NO = "BANK-OUT/2023050001",
                    CTRANS_DESC = "Biaya Buku Cek",
                    CCUST_SUPP_NAME = "PER00015 - PT PERTAMINA DRILLING SERVICES INDONESIA",
                    CUPDATE_BY = "Irma",
                    CMODULE_ID = "CB",
                    CGLACCOUNT_NO = "7103",
                    CGLACCOUNT_NAME = "Provisi & Adm Bank",
                    CCENTER_CODE = "MCC",
                    CDOC_NO = "0556/BKBCAR/05/2023",
                    CDETAIL_DESC = "Biaya Buku Cek BCA",
                    CDOC_DATE = "20240102",
                    NDEBIT_AMOUNT = 800000,
                    NCREDIT_AMOUNT = 0,
                    CCURRENCY_CODE = "IDR",
                    
                    CFROM_DEPT_CODE = "ADM",
                    CTO_DEPT_CODE = "HRD",
                    CFROM_PERIOD = "01-Jan-2024",
                    CTO_PERIOD = "31-Des-2024",
                    CCURRENCY_TYPE_NAME = "Local Currency",                    
                },
                
                new GLR00100ResultActivityReportDTO
                {
                    CREF_DATE = "20240102",
                    CTRANS_CODE = "190030",
                    CTRANSACTION_NAME = "Wire Transfer Journal",
                    CDEPT_CODE = "ADM",
                    CREF_NO = "BANK-OUT/2023050001",
                    CTRANS_DESC = "Biaya Buku Cek",
                    CCUST_SUPP_NAME = "PER00015 - PT PERTAMINA DRILLING SERVICES INDONESIA",
                    CUPDATE_BY = "Irma",
                    CMODULE_ID = "CB",
                    CGLACCOUNT_NO = "1101211",
                    CGLACCOUNT_NAME = "BCA-000853",
                    CCENTER_CODE = "MCC",
                    CDOC_NO = "0556/BKBCAR/05/2023",
                    CDETAIL_DESC = "Biaya Buku Cek BCA",
                    CDOC_DATE = "20240102",
                    NDEBIT_AMOUNT = 0,
                    NCREDIT_AMOUNT = 800000,
                    CCURRENCY_CODE = "IDR",
                    
                    CFROM_DEPT_CODE = "ADM",
                    CTO_DEPT_CODE = "HRD",
                    CFROM_PERIOD = "01-Jan-2024",
                    CTO_PERIOD = "31-Des-2024",
                    CCURRENCY_TYPE_NAME = "Local Currency",                    
                },
                
                new GLR00100ResultActivityReportDTO
                {
                    CREF_DATE = "20240102",
                    CTRANS_CODE = "910010",
                    CTRANSACTION_NAME = "Sales Invoice",
                    CDEPT_CODE = "ADM",
                    CREF_NO = "INV/2023050001/MCC",
                    CTRANS_DESC = "ELECTRICITY, ELECTRICITY AC",
                    CCUST_SUPP_NAME = "PER00015 - PT PERTAMINA DRILLING SERVICES INDONESIA",
                    CUPDATE_BY = "Irma",
                    CMODULE_ID = "CB",
                    CGLACCOUNT_NO = "7103",
                    CGLACCOUNT_NAME = "Provisi & Adm Bank",
                    CCENTER_CODE = "MCC",
                    CDOC_NO = "0556/BKBCAR/05/2023",
                    CDETAIL_DESC = "Biaya Buku Cek BCA",
                    CDOC_DATE = "20240102",
                    NDEBIT_AMOUNT = 1800000,
                    NCREDIT_AMOUNT = 0,
                    CCURRENCY_CODE = "IDR",
                    
                    CFROM_DEPT_CODE = "ADM",
                    CTO_DEPT_CODE = "HRD",
                    CFROM_PERIOD = "01-Jan-2024",
                    CTO_PERIOD = "31-Des-2024",
                    CCURRENCY_TYPE_NAME = "Local Currency",                    
                },
                
                new GLR00100ResultActivityReportDTO
                {
                    CREF_DATE = "20240102",
                    CTRANS_CODE = "910010",
                    CTRANSACTION_NAME = "Sales Invoice",
                    CDEPT_CODE = "ADM",
                    CREF_NO = "INV/2023050001/MCC",
                    CTRANS_DESC = "ELECTRICITY, ELECTRICITY AC",
                    CCUST_SUPP_NAME = "PER00015 - PT PERTAMINA DRILLING SERVICES INDONESIA",
                    CUPDATE_BY = "Irma",
                    CMODULE_ID = "CB",
                    CGLACCOUNT_NO = "1101211",
                    CGLACCOUNT_NAME = "BCA-000853",
                    CCENTER_CODE = "MCC",
                    CDOC_NO = "0556/BKBCAR/05/2023",
                    CDETAIL_DESC = "Biaya Buku Cek BCA",
                    CDOC_DATE = "20240102",
                    NDEBIT_AMOUNT = 0,
                    NCREDIT_AMOUNT = 1800000,
                    CCURRENCY_CODE = "IDR",
                    
                    CFROM_DEPT_CODE = "ADM",
                    CTO_DEPT_CODE = "HRD",
                    CFROM_PERIOD = "01-Jan-2024",
                    CTO_PERIOD = "31-Des-2024",
                    CCURRENCY_TYPE_NAME = "Local Currency",                    
                },

                new GLR00100ResultActivityReportDTO
                {
                    CREF_DATE = "20240110",
                    CTRANS_CODE = "930010",
                    CTRANSACTION_NAME = "Sales Credit Adjustment",
                    CDEPT_CODE = "ADM",
                    CREF_NO = "SCA/2023050002",
                    CTRANS_DESC = "PPH4R : BASE RENT,SERVICE",
                    CCUST_SUPP_NAME = "WIT00036 - PT. WITAMI TUNAI MANDIRI",
                    CUPDATE_BY = "Irma",
                    CMODULE_ID = "PM",
                    CGLACCOUNT_NO = "51020510",
                    CGLACCOUNT_NAME = "BASE RENT&SC",
                    CCENTER_CODE = "MCC",
                    CDOC_NO = "002/LOO/01/2024",
                    CDETAIL_DESC = "Biaya Buku Cek BCA",
                    CDOC_DATE = "20240110",
                    NDEBIT_AMOUNT = 12000000,
                    NCREDIT_AMOUNT = 0,
                    CCURRENCY_CODE = "IDR",
                    
                    CFROM_DEPT_CODE = "ADM",
                    CTO_DEPT_CODE = "HRD",
                    CFROM_PERIOD = "01-Jan-2024",
                    CTO_PERIOD = "31-Des-2024",
                    CCURRENCY_TYPE_NAME = "Local Currency",                    
                },
                
                new GLR00100ResultActivityReportDTO
                {
                    CREF_DATE = "20240110",
                    CTRANS_CODE = "930010",
                    CTRANSACTION_NAME = "Sales Credit Adjustment",
                    CDEPT_CODE = "ADM",
                    CREF_NO = "SCA/2023050002",
                    CTRANS_DESC = "PPH4R : BASE RENT,SERVICE",
                    CCUST_SUPP_NAME = "WIT00036 - PT. WITAMI TUNAI MANDIRI",
                    CUPDATE_BY = "Irma",
                    CMODULE_ID = "PM",
                    CGLACCOUNT_NO = "110301",
                    CGLACCOUNT_NAME = "A/R Tenant",
                    CCENTER_CODE = "MCC",
                    CDOC_NO = "002/LOO/01/2024",
                    CDETAIL_DESC = "Biaya Buku Cek BCA",
                    CDOC_DATE = "20240110",
                    NDEBIT_AMOUNT = 0,
                    NCREDIT_AMOUNT = 12000000,
                    CCURRENCY_CODE = "IDR",
                    
                    CFROM_DEPT_CODE = "ADM",
                    CTO_DEPT_CODE = "HRD",
                    CFROM_PERIOD = "01-Jan-2024",
                    CTO_PERIOD = "31-Des-2024",
                    CCURRENCY_TYPE_NAME = "Local Currency",                    
                }
            };

            var loSubCollection = new List<GLR00100ResultActivitySubReportDTO>
            {
                new GLR00100ResultActivitySubReportDTO
                {
                    CGLACCOUNT_NO = "7103",
                    CGLACCOUNT_NAME = "Provisi & Adm Bank",
                    CCENTER_CODE = "MCC",
                    NTOTAL_DEBIT = 2600000,
                    NTOTAL_CREDIT = 0,
                },
                new GLR00100ResultActivitySubReportDTO
                {
                    CGLACCOUNT_NO = "1101211",
                    CGLACCOUNT_NAME = "BCA-000853",
                    CCENTER_CODE = "MCC",
                    NTOTAL_DEBIT = 0,
                    NTOTAL_CREDIT = 2600000,
                },
                new GLR00100ResultActivitySubReportDTO
                {
                    CGLACCOUNT_NO = "51020510",
                    CGLACCOUNT_NAME = "BASE RENT&SC",
                    CCENTER_CODE = "PM",
                    NTOTAL_DEBIT = 12000000,
                    NTOTAL_CREDIT = 0,
                },
                new GLR00100ResultActivitySubReportDTO
                {
                    CGLACCOUNT_NO = "110301",
                    CGLACCOUNT_NAME = "A/R Tenant",
                    CCENTER_CODE = "PM",
                    NTOTAL_DEBIT = 0,
                    NTOTAL_CREDIT = 12000000,
                }
            };
            
            var loData = new GLR00100ReportResultDTO
            {
                Title = "Activity Report",
                Label = new GLR00100ReportLabelDTO(),
                Header = new GLR00100ReportHeaderBasedOnDateDTO
                {
                    CFROM_DEPT_CODE = loCollection.FirstOrDefault()?.CFROM_DEPT_CODE,
                    CTO_DEPT_CODE = loCollection.FirstOrDefault()?.CTO_DEPT_CODE,
                    CFROM_PERIOD = loCollection.FirstOrDefault()?.CFROM_PERIOD,
                    CTO_PERIOD = loCollection.FirstOrDefault()?.CTO_PERIOD,
                    CCURRENCY_TYPE_NAME = loCollection.FirstOrDefault()?.CCURRENCY_TYPE_NAME,
                    // CCURRENCY_TYPE = "L",
                    CCURRENCY_TYPE = "T",
                    CREPORT_BASED_ON = "Based On Date"
                },
                
                //assign data CREF_DATE_DISPLAY dalam loCollection lalu di assign ke DATA
                Data = loCollection.Select(x => new GLR00100ResultActivityReportDTO
                {
                    CREF_DATE = x.CREF_DATE,
                    CTRANS_CODE = x.CTRANS_CODE,
                    CTRANSACTION_NAME = x.CTRANSACTION_NAME,
                    CDEPT_CODE = x.CDEPT_CODE,
                    CREF_NO = x.CREF_NO,
                    CTRANS_DESC = x.CTRANS_DESC,
                    CCUST_SUPP_NAME = x.CCUST_SUPP_NAME,
                    CUPDATE_BY = x.CUPDATE_BY,
                    CMODULE_ID = x.CMODULE_ID,
                    CGLACCOUNT_NO = x.CGLACCOUNT_NO,
                    CGLACCOUNT_NAME = x.CGLACCOUNT_NAME,
                    CCENTER_CODE = x.CCENTER_CODE,
                    CDOC_NO = x.CDOC_NO,
                    CDETAIL_DESC = x.CDETAIL_DESC,
                    CDOC_DATE = x.CDOC_DATE,
                    NDEBIT_AMOUNT = x.NDEBIT_AMOUNT,
                    NCREDIT_AMOUNT = x.NCREDIT_AMOUNT,
                    CCURRENCY_CODE = x.CCURRENCY_CODE,
                    CCURRENCY_TYPE_NAME = x.CCURRENCY_TYPE_NAME,
                    
                    CREF_DATE_DISPLAY = !string.IsNullOrWhiteSpace(x.CREF_DATE)
                        ? DateTime.ParseExact(x.CREF_DATE, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy")
                        :"",
                    CDOC_DATE_DISPLAY = !string.IsNullOrWhiteSpace(x.CDOC_DATE)
                        ? DateTime.ParseExact(x.CDOC_DATE, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd-MMM-yyyy")
                        :"",
                }).ToList(),
                // Data = loCollection,
                
                SubData = loSubCollection
            };
            
            return loData;
        }
        
        public static GLR00100ReportWithBaseHeaderBasedOnDateDTO DefaultDataWithHeader()
        {
            var loParam = new BaseHeaderDTO
            {
                CCOMPANY_NAME = "PT. Realta Chakradarma",
                CPRINT_CODE = "001",
                CPRINT_NAME = "Activity Report",
                CUSER_ID = "rhc"
            };
            
            var loData = new GLR00100ReportWithBaseHeaderBasedOnDateDTO
            {
                BaseHeaderData = loParam,
                Data = DefaultData()
            };

            return loData;
        }
    }
}