﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class IdParametersBadRequestException:BadRequestException
    {
        public IdParametersBadRequestException():base("Parameter id is null")
        {

        }
    }
}
