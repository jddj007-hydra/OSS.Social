﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSS.Common.Extention;
using OSS.Http;
using OSS.Http.Mos;
using OSS.Social.WX;
using OSS.Social.WX.Sns;

namespace OSS.Social.Tests.WxTests
{
    [TestClass]
    public class WxAuthTest
    {
        private static WxAppCoinfig m_Config = new WxAppCoinfig()
        {
            AppSource = "11",
            AppId = "wxaa9e6cb3f03afa97",
            AppSecret = "0fc0c6f735a90fda1df5fc840e010144"
        };

        private static WxOauthApi m_AuthApi = new WxOauthApi(m_Config);
        [TestMethod]
        public void AuthTest()
        {
            var tokecRes = m_AuthApi.GetAuthAccessTokenAsync("ssss").WaitResult();
            string token = tokecRes.access_token;
        }



        [TestMethod]
        public void GetTest()
        {
            var req = new OsHttpRequest();
            req.AddressUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxaa9e6cb3f03afa97&secret=0fc0c6f735a90fda1df5fc840e010144&code=ssss&grant_type=authorization_code";
            req.HttpMothed = HttpMothed.GET;

       
            var result = req.RestSend().WaitResult();
            var resp = result.Content.ReadAsStringAsync().WaitResult();
            Assert.IsTrue(!string.IsNullOrEmpty(resp));
        }
    }
}
