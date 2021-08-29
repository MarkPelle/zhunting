using System.Collections.Generic;

namespace zhunting.BLL
{
    public record GetMediaCollectionDTO(string Name, List<string> ImageUrls);
    public record CreateMediaCollectionDTO();
    public record UpdateMediaCollectionDTO();
    public record DeleteMediaCollectionDTO();
    public record CreateHuntableDTO();
    public record UpdateHuntableDTO();
    public record DeleteHuntableDTO();
    public record CreateStaffDTO();
    public record UpdateStaffDTO();
    public record DeleteStaffDTO();
}  