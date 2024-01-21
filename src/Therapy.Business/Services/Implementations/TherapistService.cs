using Microsoft.AspNetCore.Hosting;
using Therapy.Business.CustomExceptions;
using Therapy.Business.Helperss;
using Therapy.Business.Services.Interfaces;
using Therapy.Core.Models;
using Therapy.Core.Repositories.Interfaces;

namespace Therapy.Business.Services.Implementations;

public class TherapistService : ITherapistService
{
    private readonly ITherapistRepository _therapistrepo;
    private readonly IWebHostEnvironment _env;

    public TherapistService(ITherapistRepository therapistrepo,IWebHostEnvironment env)
    {
        _therapistrepo = therapistrepo;
        _env = env;
    }

    public async Task CreateAsync(Therapist therapist)
    {
        if(therapist == null) throw new EntityIsNullException("Therapist","Entity not found !!!");
        if(therapist.Image!= null)
        {
            if (therapist.Image.ContentType != "image/png" && therapist.Image.ContentType != "image/jpeg")
            {
                throw new EntityIsNullException("Image", "Image type must be png or jpg");
            }
            if(therapist.Image.Length> 2097152)
            {
                throw new InvalidImageSizeException("Image", "Image size must be lower than 2mb");
            }
            string filename = Helper.GetFile(_env.WebRootPath,"Uploads/Therapists",therapist.Image);
            therapist.ImageUrl = filename;
            therapist.CreatedDate= DateTime.Now;
            await _therapistrepo.CreateAsync(therapist);
            await _therapistrepo.CommitAsync();
        }
        else
        {
            throw new ImageIsNullException("Image", "Image cannot be null !!!");
        }
    }

    public async void Delete(int id)
    {
        if (id <= 0 || id == null) throw new IdBelowZero("Id", "Id Is not valid");
        var data = await _therapistrepo.GetAsync(x=> x.Id == id && x.IsDeleted==false);
        if (data == null) throw new EntityIsNullException("Therapist", "Entity not found");
         _therapistrepo.DeleteAsync(data);
        await _therapistrepo.CommitAsync();
    }

    public async Task<List<Therapist>> GetAll()
    {
        return await _therapistrepo.GetAllAsync();
    }

    public async Task<Therapist> GetById(int id)
    {
        return await _therapistrepo.GetAsync(x=> x.Id == id);
    }

    public async Task UpdateAsync(Therapist therapist)
    {
        if (therapist == null) throw new EntityIsNullException("Therapist", "Entity not found !!!");
        var existTherapist = await _therapistrepo.GetAsync(x => x.Id == therapist.Id && x.IsDeleted == false);
        if (existTherapist == null) throw new EntityIsNullException("Therapist", "Entity not found!!!");
        if (therapist.Image != null)
        {
            if (therapist.Image.ContentType != "image/png" && therapist.Image.ContentType != "image/jpeg")
            {
                throw new EntityIsNullException("Image", "Image type must be png or jpg");
            }
            if (therapist.Image.Length > 2097152)
            {
                throw new InvalidImageSizeException("Image", "Image size must be lower than 2mb");
            }
            string filename = Helper.GetFile(_env.WebRootPath, "Uploads/Therapists", therapist.Image);
            string expiredpath = Path.Combine(_env.WebRootPath, "Uploads/Therapists");
            existTherapist.ImageUrl = filename;
            existTherapist.FullName = therapist.FullName;
            existTherapist.Profession = therapist.Profession;
            existTherapist.FbUrl = therapist.FbUrl;
            existTherapist.IgUrl= therapist.IgUrl;
            existTherapist.TwitterUrl= therapist.TwitterUrl;
            existTherapist.LinkedinUrl= therapist.LinkedinUrl;
            if(File.Exists(expiredpath))
            {
                File.Delete(expiredpath);
            }
            await _therapistrepo.CommitAsync();
        }
        else
        {
            existTherapist.ImageUrl = existTherapist.ImageUrl;
            existTherapist.FullName = therapist.FullName;
            existTherapist.Profession = therapist.Profession;
            existTherapist.FbUrl = therapist.FbUrl;
            existTherapist.IgUrl = therapist.IgUrl;
            existTherapist.TwitterUrl = therapist.TwitterUrl;
            existTherapist.LinkedinUrl = therapist.LinkedinUrl;
            await _therapistrepo.CommitAsync();
        }
    }
}
