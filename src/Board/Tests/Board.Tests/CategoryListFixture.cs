using System;
using System.Collections.Generic;
using System.Linq;
using Board.Contracts.Category;

namespace Board.Tests
{
    public class CategoryListFixture
    {
        public CategoryListFixture()
        {
            List = Ids.Select(x => new CategoryInfoDto
            {
                Id = x,
                Name = $"test category name {x.ToString().Substring(1, 4)}",
                CreatedAt = DateTime.Now,
                IsActive = true,
                ParentId = x
            })
                .ToList();
        }

        public static Guid[] Ids { get; } = { Guid.NewGuid(), Guid.NewGuid(), Guid.Parse("09258252-083B-439A-931E-828E7F1B4F17") };

        public List<CategoryInfoDto> List { get; }
    }
}