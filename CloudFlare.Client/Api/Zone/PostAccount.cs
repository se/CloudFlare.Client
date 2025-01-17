﻿using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zone
{
    public class PostAccount
    {
        /// <summary>
        /// Your contact email address
        /// </summary>
        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// A member's status in the account
        /// </summary>
        [JsonProperty("status")]
        public AddMembershipStatus Status { get; set; }

        /// <summary>
        /// Array of roles associated with this member
        /// </summary>
        [JsonProperty("roles")]
        public IEnumerable<AccountRole> Roles { get; set; }
    }
}