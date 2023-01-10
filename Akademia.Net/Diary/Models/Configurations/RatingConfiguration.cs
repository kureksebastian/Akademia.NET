﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Domains;

namespace Test.Models.Configurations
{
    public class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingConfiguration()
        {
            ToTable("dbo.Ratings");

            HasKey(x => x.Id);
        }
    }
}
