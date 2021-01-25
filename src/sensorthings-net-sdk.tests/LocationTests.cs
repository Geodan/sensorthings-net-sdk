﻿using NUnit.Framework;
using SensorThings.Client;
using SensorThings.Client.Extensions;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class LocationTests
    {
        private string server;
        private SensorThingsEntityHandler entityHandler;

        [SetUp]
        public void Initialize()
        {
            server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
            entityHandler = new SensorThingsEntityHandler(server);
        }

        [Test]
        public void GetLocationTest()
        {
            // act
            var location = entityHandler.GetEntity<Location>("760795").Result;

            // assert
            Assert.IsTrue(location.Id == "760795");
            Assert.IsTrue(location.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations(760795)");
            Assert.IsTrue(location.Description == "The NYP location");
            Assert.IsTrue(location.Name == "NYP_LOCATION_4321");
            Assert.IsTrue(location.EncodingType == "application/vnd.get+json");
            Assert.IsTrue(location.Feature != null);
            Assert.IsTrue(location.ThingsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations(760795)/Things");
            Assert.IsTrue(location.HistoricalLocationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations(760795)/HistoricalLocations");
        }

        [Test]
        public void GetLocationCollectionTest()
        {
            // act
            var locations = entityHandler.SearchEntities<Location>().Result;

            // assert
            Assert.IsTrue(locations.Count > 0 );
            Assert.IsTrue(locations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Locations?$top=100&$skip=100");
            Assert.IsTrue(locations.Items.Count == 100);
        }

        [Test]
        public void TestRelatedItems()
        {
            // arrange
            var location = entityHandler.GetEntity<Location>("760795").Result;

            // act
            var historicalLocations = location.GetHistoricalLocations(entityHandler).Result;
            var things = location.GetThings(entityHandler).Result;

            // assert
            Assert.IsTrue(historicalLocations.Count == 1);
            Assert.IsTrue(things.Count == 1);
            Assert.IsTrue(things.Items[0].Id == "760740");
        }
    }
}
