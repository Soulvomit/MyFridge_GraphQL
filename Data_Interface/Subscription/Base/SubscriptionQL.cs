﻿using Client_Model.Model;

namespace Data_Interface.Subscription.Base
{
    public class SubscriptionQL
    {
        [Subscribe]
        public AddressCto AddressCreated([EventMessage]AddressCto cto)
        {
            return cto;
        } 
    }
}
