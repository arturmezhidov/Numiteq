﻿namespace Numiteq.Common.Entities
{
    public class MainService : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int SortNumber { get; set; }

        public string Icon { get; set; }
    }
}