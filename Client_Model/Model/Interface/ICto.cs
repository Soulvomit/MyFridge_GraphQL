﻿namespace Client_Model.Model.Interface
{
    public interface ICto
    {
        public int Id { get; set; }
        public string SerializeToCreateInputType();
        public string SerializeToUpdateInputType();
    }
}
