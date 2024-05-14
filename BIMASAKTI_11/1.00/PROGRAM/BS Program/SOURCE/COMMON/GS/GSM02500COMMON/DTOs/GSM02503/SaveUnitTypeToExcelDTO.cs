﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GSM02500COMMON.DTOs.GSM02503
{
    public class SaveUnitTypeToExcelDTO
    {
        public int No { get; set; } = 0;
        public string UnitTypeCode { get; set; } = "";
        public string UnitTypeName { get; set; } = "";
        public string UnitTypeCtg { get; set; } = "";
        public string Description { get; set; } = "";
        public bool Active { get; set; } = false;
        public string NonActiveDate { get; set; } = "";
        public decimal GrossAreaSize { get; set; } = 0;
        public decimal NetAreaSize { get; set; } = 0;
        public string Valid { get; set; } = "";
        public string Notes { get; set; } = "";
    }
}
