﻿namespace Lookup_GLCOMMON.DTOs.GLL00110
{
    public class GLL00110ParameterGetRecordDTO
    {
        public string CUSER_ID { get; set; }
        public string CCOMPANY_ID { get; set; }
        public string? CTRANS_CODE { get; set; } = "";
        public string CFROM_DEPT_CODE { get; set; }
        public string CTO_DEPT_CODE { get; set; }
        public string CFROM_DATE { get; set; }
        public string CTO_DATE { get; set; }
        public string CLANGUAGE_ID { get; set; }
        public string? CSEARCH_TEXT { get; set; } = "";

    }
}
