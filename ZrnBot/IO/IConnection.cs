﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZrnBot.IO
{
    interface IConnection
    {
        Uri ServerUri { get; }

        Task<bool> SendStringAsying(IIrcMessage ircMessage);
    }
}
