﻿using HotelReservation.Model;

namespace HotelReservation.Services
{
    public interface IGuestService
    {
        Task<List<Guest>> GetGuest();
        Task<Guest> GetGuest(int id);
        Task<int> PostGuest(Guest guest);  
        Task<int> DeleteGuest(int id);  
        Task<int> UpdateGuest(Guest guest);  
    }
}
