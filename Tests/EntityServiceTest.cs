using System;
using Xunit;

namespace tests
{
    public class EntityServiceTest
    {
        private EntityService _service = new EntityService();
        public EntityServiceTest()
        {
            _service.Add(new Entity
            {
                Id = new Guid("cfaa0d3f-7fea-4423-9f69-ebff826e2f89"),
                OperationDate = new DateTime(2022, 8, 18, 0, 0, 0, DateTimeKind.Local),
                Amount = 23.05M
            });
        }

        [Fact]
        public void TestAddSuccess()
        {
            var result = _service.Add(new Entity
            {
                Id = new Guid("cfaa0d3f-7fea-4423-9f69-ebff826e2f92"),
                OperationDate = new DateTime(2022, 8, 16, 0, 0, 0, DateTimeKind.Local),
                Amount = 23.05M
            });
            Assert.True(result);
        }

        [Fact]
        public void TestAddFailed()
        {
            var result = _service.Add(new Entity
            {
                Id = new Guid("cfaa0d3f-7fea-4423-9f69-ebff826e2f89"),
                OperationDate = new DateTime(2022, 8, 16, 0, 0, 0, DateTimeKind.Local),
                Amount = 23.05M
            });
            Assert.False(result);
        }

        [Fact]
        public void TestGetSuccess()
        {
            var result = _service.Get(new Guid("cfaa0d3f-7fea-4423-9f69-ebff826e2f89"));
            Assert.NotNull(result);
        }
    }
}
