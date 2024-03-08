﻿using LMT03500Common.DTOs;
using LMT03500Model.ViewModel;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Exceptions;

namespace LMT03500Front;

public partial class LMT03500BuildingLookup
{
    private LMT03500BuildingLookupViewModel _viewModel = new();
    private R_Conductor _conductorRef;
    private R_Grid<LMT03500BuildingDTO> _gridRef = new();

    protected override async Task R_Init_From_Master(object poParameter)
    {
        var loEx = new R_Exception();

        try
        {
            await _gridRef.R_RefreshGrid(poParameter);
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        loEx.ThrowExceptionIfErrors();
    }
    
    private async Task GetList(R_ServiceGetListRecordEventArgs eventArgs)
    {
        var loEx = new R_Exception();

        try
        {
            await _viewModel.GetList(eventArgs.Parameter); 
            eventArgs.ListEntityResult = _viewModel.GridList;
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        loEx.ThrowExceptionIfErrors();
    }
    
    
    public async Task OnClickOkAsync()
    {
        var loData = _gridRef.GetCurrentData();
        await this.Close(true, loData);
    }
    public async Task OnClickCloseAsync()
    {
        await this.Close(true, null);
    }
}