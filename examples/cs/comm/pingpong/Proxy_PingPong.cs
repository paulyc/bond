﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// hand-written proxy. This will be generated eventually, either via gbc or reflection or some combination of.
namespace Bond.Examples.PingPong
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bond.Comm;

    public class Proxy_PingPong : IPingPongService
    {
        private IRequestResponseConnection m_connection;

        public Proxy_PingPong(IRequestResponseConnection connection)
        {
            m_connection = connection;
        }

        public async Task<PingResponse> PingAsync(PingRequest request)
        {
            var message = new Message<PingRequest>(request);
            var response = await m_connection.RequestResponseAsync<PingRequest, PingResponse>("Bond.Examples.PingPong.Ping", message, CancellationToken.None);
            return response.Payload.Deserialize<PingResponse>();
        }
    }
}
