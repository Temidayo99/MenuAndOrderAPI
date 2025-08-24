using MenuAndOrder.Data.AppResponses;
using MenuAndOrder.Data.DatabaseEntities;
using MenuAndOrder.Data.DataContext;
using MenuAndOrder.Data.DTOs.GenericDto;
using MenuAndOrder.Data.DTOs.MenuDTO.Request;
using MenuAndOrder.Data.DTOs.MenuDTO.Response;
using MenuAndOrder.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAndOrder.Data.Services
{
    public class MenuService: IMenuService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MenuService> _logger;
        public MenuService(AppDbContext context) 
        {
            _context = context;
        }    

        public async Task<BaseResponse<List<MenuResponse>>> GetMenus()
        {
            try
            {
                var menuItems = await _context.MenuItems.Select(x => new MenuResponse() 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    IsAvailable = x.IsAvailable                    
                }).ToListAsync();

                if (menuItems.Count > 0) 
                {
                    return new BaseResponse<List<MenuResponse>>(
                        menuItems, ResponseCodes.Success, ResponseMessages.Success);
                }
                return new BaseResponse<List<MenuResponse>>(menuItems, ResponseCodes.MenuNotFound, ResponseMessages.MenuNotFound);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<MenuResponse>>(null, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public async Task<BaseResponse<MenuResponse>> GetMenuById(long id)
        {
            try
            {
                var menuItem = await _context.MenuItems
                    .Where(x => x.Id == id)
                    .Select(x => new MenuResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    IsAvailable = x.IsAvailable
                }).FirstOrDefaultAsync();

                if (menuItem != null)
                {
                    return new BaseResponse<MenuResponse>(
                        menuItem, ResponseCodes.Success, ResponseMessages.Success);
                }
                return new BaseResponse<MenuResponse>(menuItem, ResponseCodes.MenuNotFound, ResponseMessages.MenuIdNotFound);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MenuResponse>(null, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public async Task<BaseResponse<bool>> AddMenu(AddMenuRequest request)
        {
            try
            {
                var menuExist = await _context.MenuItems.FirstOrDefaultAsync(x => x.Name == request.Name);
                if (menuExist == null)
                {
                    var newMenu = new MenuItem
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Price = request.Price,
                        IsAvailable = request.IsAvailable
                    };
                    await _context.MenuItems.AddAsync(newMenu);
                    await _context.SaveChangesAsync();

                    return new BaseResponse<bool>(true, ResponseCodes.Success, ResponseMessages.MenuCreationSuccessful);
                }

                return new BaseResponse<bool>(false, ResponseCodes.MenuCreationFailed, ResponseMessages.MenuCreationFailed);

            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error occurred while creating the menu");
                return new BaseResponse<bool>(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public async Task<BaseResponse<bool>> UpdateMenu(long id, UpdateMenuRequest request)
        {
            try
            {
                var menu = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
                if (menu == null)
                {
                    return new BaseResponse<bool>(false, ResponseCodes.MenuNotFound, ResponseMessages.MenuIdNotFound);
                }

                if (!string.IsNullOrEmpty(request.Description))
                {
                    menu.Description = request.Description;
                }
                menu.Price = request.Price;              
                menu.IsAvailable = request.IsAvailable;

                //_context.MenuItems.Update(menu);
                await _context.SaveChangesAsync();

                return new BaseResponse<bool>(true, ResponseCodes.Success, ResponseMessages.MenuUpdateSuccessful);       
            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error occurred while updating the menu");
                return new BaseResponse<bool>(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }

        public async Task<BaseResponse<bool>> DeleteMenu(long id)
        {
            try
            {
                var menu = _context.MenuItems.FirstOrDefault(x => x.Id == id);

                if (menu == null)
                {
                    return new BaseResponse<bool>(false, ResponseCodes.MenuNotFound, ResponseMessages.MenuIdNotFound);
                }

                _context.MenuItems.Remove(menu);
                await _context.SaveChangesAsync();

                return new BaseResponse<bool>(true, ResponseCodes.Success, ResponseMessages.MenuDeletedSuccessful);

            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error occurred while deleting the menu");
                return new BaseResponse<bool>(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }
    }
}
