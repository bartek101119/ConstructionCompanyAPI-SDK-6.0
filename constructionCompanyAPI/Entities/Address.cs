﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace constructionCompanyAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Voivodeship { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public virtual ConstructionCompany ConstructionCompany { get; set; }
    }
}
