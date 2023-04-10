using System;
using Board.Domain.Adverts;
using Board.Domain.Categories;
using Board.Infrastucture.DataAccess;

namespace Board.Api.Tests
{
    public static class DataSeedHelper
    {
        public static Guid TestAdvertId { get; set; }
        public static Guid TestCategoryId { get; set; }

        public static void InitializeDbForTests(BoardDbContext db)
        {
            var testCategory = new Category
            {
                Name = "test_cat_1",
                IsActive = true,
                Created = DateTime.UtcNow
            };
            db.Add(testCategory);

            TestCategoryId = testCategory.Id;

            var advert = new Advert
            {
                Name = "test_advert_name",
                Description = "test_desc",
                IsActive = true,
                Created = DateTime.UtcNow,
                CategoryId = testCategory.Id,
                Address = "new_prostokvashino"
            };
            db.Add(advert);

            db.SaveChanges();

            TestAdvertId = advert.Id;
        }
    }
}