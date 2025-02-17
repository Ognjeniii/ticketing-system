namespace ticketing_system.ViewModels.Tickets
{
    public class SearchTicketViewModelComposite
    {
        public SearchTicketViewModel searchTicketViewModel { get; set; }
        public List<ListTicketsViewModel> listTicketsViewModel { get; set; } = new List<ListTicketsViewModel>();

        public SearchTicketViewModelComposite()
        {

        }

        public SearchTicketViewModelComposite(SearchTicketViewModel search)
        {
            searchTicketViewModel = search;
            listTicketsViewModel = new List<ListTicketsViewModel>();
        }
    }
}
