using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BootcampTap.Core;
using BootcampTap.Core.Models;
using BootcampTap.Core.ViewModels;
using GalaSoft.MvvmLight.Views;

namespace BootcampTap.Droid.Activities
{
    [Activity(Label = "StoreMapActivity")]
    public class StoreMapActivity : ActivityBase, IOnMapReadyCallback
    {
        private StoreMapViewModel _viewModel;
        private MapView _mapView;
        private GoogleMap _map;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_store_map);

            _viewModel = App.Container.GetInstance<StoreMapViewModel>();
            _mapView = FindViewById<MapView>(Resource.Id.mapView);
            _mapView.OnCreate(savedInstanceState);

            _mapView.GetMapAsync(this);

            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Stores))
            {
                LoadStoresToMap();
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            LoadStoresToMap();
        }
       
        private void LoadStoresToMap()
        {
            if (_mapView == null || _viewModel.Stores == null)
                return;

            foreach (var store in _viewModel.Stores)
            {
                var markerOptions = CreateMarker(store);
                _map.AddMarker(markerOptions);
            }
        }

        private MarkerOptions CreateMarker(Store store)
        {
            LatLng latLng;
            try
            {
                latLng = new LatLng(double.Parse(store.Lat), double.Parse(store.Lng));
            }
            catch(Exception e)
            {
                latLng = new LatLng(0, 0);
            }

            var markerOptions = new MarkerOptions()
                .SetPosition(latLng)
                .Draggable(false)
                .SetTitle(store.Name);
            return markerOptions;
        }

    }
}