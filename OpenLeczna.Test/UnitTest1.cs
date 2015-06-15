using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenLeczna.App_Start;

namespace OpenLeczna.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMappings()
        {
            App_Start.AutoMapperConfig.RegisterMappings();

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
