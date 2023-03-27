using DemoMinimalApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalApiPaladino.Data;
using MiniValidation;
using System.Runtime.CompilerServices;

namespace MinimalApiPaladino.Endpoints;

public static class MapMasterEndPoints
{
    public static void MapMasterEndpoints( this WebApplication app)
    {
        #region Actions
     
            //// Configuração do middleware de autorização
            //app.UseAuthorization();

            app.MapGet("/", () => "Bem vindo a API do PALADINO!").ExcludeFromDescription();

            //#region Registro de Usuário

            //app.MapPost("/registro", [AllowAnonymous] async (
            //       SignInManager<IdentityUser> signInManager,
            //       UserManager<IdentityUser> userManager,
            //       IOptions<AppJwtSettings> appJwtSettings,
            //       RegisterUser registerUser) =>
            //{
            //    if (registerUser == null)
            //        return Results.BadRequest("Usuário não informado");

            //    if (!MiniValidator.TryValidate(registerUser, out var errors))
            //        return Results.ValidationProblem(errors);

            //    var user = new IdentityUser
            //    {
            //        UserName = registerUser.Email,
            //        Email = registerUser.Email,
            //        EmailConfirmed = true
            //    };

            //    var result = await userManager.CreateAsync(user, registerUser.Password);

            //    if (!result.Succeeded)
            //        return Results.BadRequest(result.Errors);

            //    var jwt = new JwtBuilder()
            //                .WithUserManager(userManager)
            //                .WithJwtSettings(appJwtSettings.Value)
            //                .WithEmail(user.Email)
            //                .WithJwtClaims()
            //                .WithUserClaims()
            //                .WithUserRoles()
            //                .BuildUserResponse();

            //    return Results.Ok(jwt);

            //}).ProducesValidationProblem()
            //     .Produces(StatusCodes.Status200OK)
            //     .Produces(StatusCodes.Status400BadRequest)
            //     .WithName("RegistroUsuario")
            //     .WithTags("Usuario");


            //#endregion

            //#region Login

            //app.MapPost("/login", [AllowAnonymous] async (
            //     SignInManager<IdentityUser> signInManager,
            //     UserManager<IdentityUser> userManager,
            //     IOptions<AppJwtSettings> appJwtSettings,
            //     LoginUser loginUser) =>
            //{
            //    if (loginUser == null)
            //        return Results.BadRequest("Usuário não informado");

            //    if (!MiniValidator.TryValidate(loginUser, out var errors))
            //        return Results.ValidationProblem(errors);

            //    var result = await signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            //    if (result.IsLockedOut)
            //        return Results.BadRequest("Usuário bloqueado");

            //    if (!result.Succeeded)
            //        return Results.BadRequest("Usuário ou senha inválidos");

            //    var jwt = new JwtBuilder()
            //                .WithUserManager(userManager)
            //                .WithJwtSettings(appJwtSettings.Value)
            //                .WithEmail(loginUser.Email)
            //                .WithJwtClaims()
            //                .WithUserClaims()
            //                .WithUserRoles()
            //                .BuildUserResponse();

            //    return Results.Ok(jwt);

            //}).ProducesValidationProblem()
            //   .Produces(StatusCodes.Status200OK)
            //   .Produces(StatusCodes.Status400BadRequest)
            //   .WithName("LoginUsuario")
            //   .WithTags("Usuario");


            //#endregion

            #region GetTodosMasters

            app.MapGet("/masters",  async (PaladinoDbContext context) =>
            {
                var masters = await context.Masters.ToListAsync();

                return masters.Any()
                    ? Results.Ok(masters)
                    : Results.NotFound();
            }).Produces<Master>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound)
              .WithName("GetAllMasters")
              .WithTags("Master");


        #endregion

        #region GetMasterPorId

        app.MapGet("/master/{id}", async (

            PaladinoDbContext context,
            int id) =>

            await context.Masters.FindAsync(id)
                is Master master
                    ? Results.Ok(master)
                    : Results.NotFound())

          .Produces<Master>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithName("GetMasterPorId")
          .WithTags("Master");

        #endregion

        #region Get Lista de Master Por Responsável

        app.MapGet("/master/Responsavel/{Responsavel}", async (

            PaladinoDbContext context,
            string search) =>

             await context.Masters
                .Where(m => string.IsNullOrEmpty(search)
                    || m.Responsavel.Contains(search))
                .ToListAsync()
                    is List<Master> master && master.Any()
                        ? Results.Ok(master)
                        : Results.NotFound())

          .Produces<Master>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithName("GetListaMasterPorResponsavel")
          .WithTags("Responsável");

        #endregion

        #region Get Lista de Master Por Domínio

        app.MapGet("/master/Dominio/{Dominio}", async (

            PaladinoDbContext context,
            string search) =>

             await context.Masters
                .Where(m => string.IsNullOrEmpty(search)
                    || m.Dominio.Contains(search))
                .ToListAsync()
                    is List<Master> master && master.Any()
                        ? Results.Ok(master)
                        : Results.NotFound())

          .Produces<Master>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithName("GetListaMasterPorDominio")
          .WithTags("Dominio");

        #endregion

        #region Get Lista de Master Por Ofício

        app.MapGet("/master/Oficio/{Oficio}", async (

            PaladinoDbContext context,
            string search) =>

             await context.Masters
                .Where(m => string.IsNullOrEmpty(search)
                    || m.Oficio.Contains(search))
                .ToListAsync()
                    is List<Master> master && master.Any()
                        ? Results.Ok(master)
                        : Results.NotFound())

          .Produces<Master>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound)
          .WithName("GetListaMasterPorOficio")
          .WithTags("Ofício");

        #endregion

               
        #region Inclui Master

        app.MapPost("/master", async (
                    PaladinoDbContext context,
                    Master master) =>
            {
                if (!MiniValidator.TryValidate(master, out var errors))
                    return Results.ValidationProblem(errors);

                context.Masters.Add(master);
                var result = await context.SaveChangesAsync();

                return result > 0
                    ? Results.CreatedAtRoute("GetMasterPorId", new { id = master.Id }, master)
                    : Results.BadRequest("Houve um problema ao salvar o registro");

            }).ProducesValidationProblem()
                  .Produces<Master>(StatusCodes.Status201Created)
                  .Produces(StatusCodes.Status400BadRequest)
                  .WithName("PostMaster")
                  .WithTags("Master");


            #endregion

            #region Atualiza Master Por Id

            app.MapPut("/master/{id}",  async (
                   int id,
                   PaladinoDbContext context,
                   Master master) =>
            {
                var masterBanco = await context.Masters.FindAsync(id);
                if (masterBanco == null) return Results.NotFound();

                masterBanco.Atualiza(master);
                

                if (!MiniValidator.TryValidate(masterBanco, out var errors))
                    return Results.ValidationProblem(errors);

                context.Masters.Update(masterBanco);
                var result = await context.SaveChangesAsync();

                return result > 0
                    ? Results.NoContent()
                    : Results.BadRequest("Houve um problema ao salvar o registro");

            }).ProducesValidationProblem()
               .Produces(StatusCodes.Status204NoContent)
               .Produces(StatusCodes.Status400BadRequest)
               .WithName("AtualizaMasterPorId")
               .WithTags("Master");

            #endregion

            #region Deleta Master

            app.MapDelete("/master/{id}",  async (
                    int id,
                    PaladinoDbContext context) =>
            {
                var master = await context.Masters.FindAsync(id);
                if (master == null) return Results.NotFound();

                context.Masters.Remove(master);
                var result = await context.SaveChangesAsync();

                return result > 0
                    ? Results.NoContent()
                    : Results.BadRequest("Houve um problema ao salvar o registro");

            }).Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("DeleteMaster")
                .WithTags("Master");




            #endregion
        }
        #endregion




    }
