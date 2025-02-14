﻿using CommunityToolkit.Mvvm.ComponentModel;
using Project2FA.Core.Utils;
using Project2FA.Helpers;
using Project2FA.Repository.Models;
using Project2FA.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UNOversal.Services.Serialization;

namespace Project2FA.ViewModels
{
    public class EditAccountViewModelBase : ObservableObject
    {
        private TwoFACodeModel _twoFACodeModel;
        private string _tempIssuer, _tempLabel, _tempAccountIconName, _tempNotes, _tempIconLabel;
        private FontIdentifikationCollectionModel _iconNameCollectionModel;
        private bool _isEditBoxVisible;
        private bool _notesExpanded = true;
        private bool _isPrimaryBTNEnabled;

        public ObservableCollection<CategoryModel> TempAccountCategoryList { get; } = new ObservableCollection<CategoryModel>();
        public ObservableCollection<CategoryModel> GlobalTempCategories { get; } = new ObservableCollection<CategoryModel>();
        public ICommand CancelButtonCommand { get; internal set; }
        public ICommand PrimaryButtonCommand { get; internal set; }
        public ICommand DeleteAccountIconCommand { get; internal set; }
        public ICommand EditAccountIconCommand { get; internal set; }

        public ISerializationService SerializationService { get; internal set; }
        public EditAccountViewModelBase()
        {
#if WINDOWS_UWP
            NotesExpanded = !IsProVersion;
#endif
        }
        public TwoFACodeModel Model
        {
            get => _twoFACodeModel;
            set
            {
                if (SetProperty(ref _twoFACodeModel, value))
                {
                    TempIssuer = Model.Issuer;
                    TempLabel = Model.Label;
                    TempAccountIconName = Model.AccountIconName;
                    if (DataService.Instance.GlobalCategories != null && DataService.Instance.GlobalCategories.Count > 0)
                    {
                        GlobalTempCategories.AddRange(DataService.Instance.GlobalCategories);
                    }
                    if (!string.IsNullOrWhiteSpace(value.Notes))
                    {
                        TempNotes = Model.Notes;
                    }
                    else
                    {
                        TempNotes = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the inputs are correct and enables / disables the submit button
        /// </summary>
        private void CheckInputs()
        {
            IsPrimaryBTNEnable = !string.IsNullOrWhiteSpace(TempLabel) && !string.IsNullOrEmpty(TempIssuer);
        }

        public FontIdentifikationCollectionModel IconNameCollectionModel
        {
            get => _iconNameCollectionModel;
            private set => _iconNameCollectionModel = value;
        }
        public string TempIssuer
        {
            get => _tempIssuer;
            set
            {
                if(SetProperty(ref _tempIssuer, value))
                {
                    CheckInputs();
                }
            }
        }
        public string TempLabel
        {
            get => _tempLabel;
            set
            {
                if (SetProperty(ref _tempLabel, value))
                {
                    CheckInputs();
                }
            }
        }
        public string TempNotes
        {
            get => _tempNotes;
            set => SetProperty(ref _tempNotes, value);
        }

        
        public string TempAccountIconName
        {
            get => _tempAccountIconName;
            set
            {
                SetProperty(ref _tempAccountIconName, value);
            }
        }
        public bool IsPrimaryBTNEnable
        {
            get => _isPrimaryBTNEnabled;
            set => SetProperty(ref _isPrimaryBTNEnabled, value);
        }

        public string TempIconLabel
        {
            get => _tempIconLabel;
            set => SetProperty(ref _tempIconLabel, value);
        }
        public bool IsEditBoxVisible
        {
            get => _isEditBoxVisible;
            set => SetProperty(ref _isEditBoxVisible, value);
        }
        public bool NotesExpanded 
        { 
            get => _notesExpanded;
            set => SetProperty(ref _notesExpanded, value); 
        }

#if WINDOWS_UWP
        public bool IsProVersion
        {
            get => SettingsService.Instance.IsProVersion;
        }
#endif

        //        public async Task LoadIconNameCollection()
        //        {
        //            try
        //            {
        //                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/JSONs/simpleicons.json"));
        //                IRandomAccessStreamWithContentType randomStream = await file.OpenReadAsync();
        //                using (StreamReader r = new StreamReader(randomStream.AsStreamForRead()))
        //                {
        //                    IconNameCollectionModel = SerializationService.Deserialize<FontIdentifikationCollectionModel>(await r.ReadToEndAsync());
        //                }
        //            }
        //            catch (Exception exc)
        //            {
        //#if WINDOWS_UWP
        //                Project2FA.UWP.TrackingManager.TrackException(nameof(LoadIconNameCollection), exc);
        //#endif
        //                //TOOD add exception dialog
        //            }

        //        }

        //public async Task LoadIconSVG()
        //{
        //    (bool success, string iconStr) = await SVGColorHelper.GetSVGIconWithThemeColor(Model.IsFavourite, TempAccountIconName, Model.IsFavourite);
        //    if (success)
        //    {
        //        TempAccountSVGIcon = iconStr;
        //    }
        //}
    }
}
