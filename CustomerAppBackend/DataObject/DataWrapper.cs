﻿using System;

namespace CustomerAppBackend.DataObject
{
    public class DataWrapper<T>
    {
        public DataWrapper()
        {
        }

        public string Error
        {
            get;
            set;
        }

        public T Data
        {
            get;
            set;
        }
    }
}

