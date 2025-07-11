﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
		const int maxPageSize = 50;

		// Auto Implemented Property
        public int PageNumber { get; set; }

		// FUll Prop
		private int _pageSize;

		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value>maxPageSize ? maxPageSize : value; }
		}

        public string? OrderBy { get; set; }

        public String? Fields { get; set; }



    }
}
