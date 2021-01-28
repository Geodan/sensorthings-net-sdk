﻿using System.Collections.ObjectModel;

using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class Sensor:AbstractEntity
    {
        private string _name;
        private string _description;
        private object _metadata;
        private string _encodingType;
        private string _datastreamsNavigationLink;
        private ObservableCollection<Datastream> _datastreams;

        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [JsonProperty("description")]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        [JsonProperty("metadata")]
        public object Metadata
        {
            get => _metadata;
            set => SetProperty(ref _metadata, value);
        }

        [JsonProperty("encodingType")]
        public string EncodingType
        {
            get => _encodingType;
            set => SetProperty(ref _encodingType, value);
        }

        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink
        {
            get => _datastreamsNavigationLink;
            set => SetProperty(ref _datastreamsNavigationLink, value);
        }

        [JsonProperty("Datastreams")]
        public ObservableCollection<Datastream> Datastreams
        {
            get => _datastreams;
            set => SetProperty(ref _datastreams, value);
        }
    }
}
