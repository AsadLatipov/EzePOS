﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Business.Models
{
    public class ErrorModel
    {
        public ErrorModel(int? code = null, string? message = null)
        {
            Code = code;
            Message = message;
        }

        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
