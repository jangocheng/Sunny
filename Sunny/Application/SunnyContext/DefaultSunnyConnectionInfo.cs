﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sunny.Application.Feature;

namespace Sunny.Application
{
    public class DefaultSunnyConnectionInfo : SunnyConnectionInfo
    {
        private readonly static FeatureReference<ISunnyConnectionInfoFeature> featureReference = new FeatureReference<ISunnyConnectionInfoFeature>(new DefaultConnectionInfoFeature());
        public DefaultSunnyConnectionInfo(SunnyContext context)
        {
            this.SunnyContext = context;
            this.Feature = featureReference.Fetch(this.SunnyContext.Features);
        }

    
        private SunnyContext SunnyContext { get; }
        private ISunnyConnectionInfoFeature Feature { get; }
        public override string Id => this.Feature.ConnectionId;
        public override IPAddress RemoteIpAddress => this.Feature.RemoteIpAddress;
        public override int RemotePort => this.Feature.RemotePort;
        public override IPAddress LocalIpAddress => this.Feature.LocalIpAddress;
        public override int LocalPort => this.Feature.LocalPort;
        public override object ServerContext => this.Feature.ServerContext;
    }
}
