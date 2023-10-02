using Blazored.Modal;
using Blazored.Modal.Services;
using MealOrdering.Client.CustomComponents.ModelComponents;


namespace MealOrdering.Client.Utils
{
    public class ModalManager
    {
        private readonly IModalService modalService;
        //https://github.com/Blazored/Modal
        public ModalManager(IModalService ModalService)
        {
            modalService = ModalService;
        }
        public async Task ShowMessageAsync(String Title, String Message,int Duration=0)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);
            var modalRef = modalService.Show<ShowMessageModalComponent>(Title, mParams);
            if(Duration >0)
            {
                await Task.Delay(Duration);
                modalRef.Close();

            }
            await modalRef.Result;
        }

        public async Task<bool> ConfirmationAsync(String Title,String Message)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);
            var modalRef = modalService.Show<ConfirmationPopopComponent>(Title, mParams);
            var modalResult=await modalRef.Result;
            return !modalResult.Cancelled;

        }
    }
}
