using MenuAndOrder.Data.DTOs.GenericDto;
using MenuAndOrder.Data.DTOs.MenuDTO.Request;
using MenuAndOrder.Data.DTOs.MenuDTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.Interfaces
{
    public interface IMenuService
    {
        Task<BaseResponse<List<MenuResponse>>> GetMenus();
        Task<BaseResponse<MenuResponse>> GetMenuById(long id);
        Task<BaseResponse<bool>> AddMenu(AddMenuRequest request);
        Task<BaseResponse<bool>> UpdateMenu(long id, UpdateMenuRequest request);
        Task<BaseResponse<bool>> DeleteMenu(long id);
    }
}
