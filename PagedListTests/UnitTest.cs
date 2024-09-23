using ListPager;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PagedListTests
{
    public class UnitTest
    {
        [Fact]
        public void ToPagedList_ShouldReturnCorrectPagedData()
        {
            var data = GetSampleData();
            int pageSize = 5;
            int pageNumber = 2;

            var pagedList = PagedList<TestData>.ToPagedList(data.AsQueryable(), pageSize, pageNumber);

            Assert.Equal(2, pagedList.TotalPages);
            
        }
        private List<TestData> GetSampleData()
        {
            return new List<TestData>
            {
                new TestData { Id = 1, Name = "Item 1" },
                new TestData { Id = 2, Name = "Item 2" },
                new TestData { Id = 3, Name = "Item 3" },
                new TestData { Id = 4, Name = "Item 4" },
                new TestData { Id = 5, Name = "Item 5" },
                new TestData { Id = 6, Name = "Item 6" },
                new TestData { Id = 7, Name = "Item 7" },
                new TestData { Id = 8, Name = "Item 8" },
                new TestData { Id = 9, Name = "Item 9" },
                new TestData { Id = 10, Name ="Item 10"}
            };
        }

        public class TestData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}