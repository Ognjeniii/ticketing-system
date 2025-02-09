namespace ticketing_system.ViewModels.Tickets
{
    public class SearchTicketViewModelComposite
    {
        public SearchTicketViewModel searchTicketViewModel { get; set; }
        public ListTicketsViewModel listTicketsViewModel { get; set; } = new ListTicketsViewModel();

        public SearchTicketViewModelComposite()
        {

        }

        public SearchTicketViewModelComposite(SearchTicketViewModel search)
        {
            searchTicketViewModel = search;
            listTicketsViewModel = new ListTicketsViewModel();
        }
    }
}
