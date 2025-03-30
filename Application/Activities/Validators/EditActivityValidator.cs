using Application.Activities.Commands;
using Application.Activities.DTOs;

namespace Application.Activities.Validators;

public class EditActivityValidator()
    : BaseActivityValidator<UpdateActivity.Command, UpdateActivityDto>(x => x.UpdateActivityDto);