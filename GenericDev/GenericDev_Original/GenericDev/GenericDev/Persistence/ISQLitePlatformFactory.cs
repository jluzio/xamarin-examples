﻿using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDev.Persistence
{
    public interface ISQLitePlatformFactory
    {
        ISQLitePlatform GetInstance();
    }
}
