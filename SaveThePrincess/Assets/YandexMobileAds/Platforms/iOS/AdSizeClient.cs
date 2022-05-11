/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for iOS (C) 2019 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System;
using YandexMobileAds.Base;
using System.Collections.Generic;

namespace YandexMobileAds.Platforms.iOS
{
    #if (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
    
    public class AdSizeClient : IDisposable
    {
        public string ObjectId { get; private set; }

        public AdSizeClient(AdSize adSize)
        {
            if (adSize.AdSizeType == AdSizeType.Sticky)
            {
                this.ObjectId = AdSizeBridge.YMAUnityCreateStickyAdSize(adSize.Width);
            }
            else if (adSize.AdSizeType == AdSizeType.Flexible)
            {
                this.ObjectId = GetFlexibleAdSizeObjectId(adSize);
            }
            else if (adSize.AdSizeType == AdSizeType.Fixed)
            {
                this.ObjectId = AdSizeBridge.YMAUnityCreateFixedAdSize(adSize.Width, adSize.Height);
            }
        }

        private string GetFlexibleAdSizeObjectId(AdSize adSize)
        {
            string objectId = null;
            if (adSize.Height == AdSize.NotSpecified && adSize.Width == AdSize.NotSpecified)
            {
                objectId = AdSizeBridge.YMAUnityCreateFlexibleAdSize();
            }
            else if (adSize.Height == AdSize.NotSpecified)
            {
                objectId = AdSizeBridge.YMAUnityCreateFlexibleAdSizeWithWidth(adSize.Width);
            }
            else
            {
                objectId = AdSizeBridge.YMAUnityCreateFlexibleAdSizeWithSize(adSize.Width, adSize.Height);
            }

            return objectId;
        }

        public void Destroy()
        {
            ObjectBridge.YMAUnityDestroyObject(this.ObjectId);
        }

        public void Dispose()
        {
            this.Destroy();
        }

        ~AdSizeClient()
        {
            this.Destroy();
        }
    }

    #endif
}