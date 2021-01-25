﻿using System;
using System.Collections.ObjectModel;

using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class HistoricalLocation : AbstractEntity
    {
        private DateTime _time;
        private string _locationsNavigationLink;
        private string _thingNavigationLink;
        private ObservableCollection<Location> _locations;
        private Thing _thing;

        [JsonProperty("time")]
        public DateTime Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink
        {
            get => _locationsNavigationLink;
            set => SetProperty(ref _locationsNavigationLink, value);
        }

        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink
        {
            get => _thingNavigationLink;
            set => SetProperty(ref _thingNavigationLink, value);
        }

        [JsonProperty("Locations")]
        public ObservableCollection<Location> Locations
        {
            get => _locations;
            set => SetProperty(ref _locations, value);
        }

        [JsonProperty("Thing")]
        public Thing Thing
        {
            get => _thing;
            set => SetProperty(ref _thing, value);
        }
    }
}
