﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GSM02500COMMON.DTOs.GSM02540
{
    public class UploadOtherUnitTypeSaveDTO
    {
        public int NO { get; set; } = 0;
        public string OtherUnitTypeCode { get; set; } = "";
        public string OtherUnitTypeName { get; set; } = "";
        public bool Active { get; set; } = false;
        public string NonActiveDate { get; set; } = "";
        public decimal GrossAreaSize { get; set; } = 0;
        public decimal NetAreaSize { get; set; } = 0;
        public decimal CommonArea { get; set; } = 0;
    }
}
