
using System.Collections.Generic;

namespace services.NSI{
public interface INSI{
    /// <summary>
    /// Возвращает список подразделений, являющихся дочерними по отношению к переданному <paramref name="parent"/>
    /// </summary>
    /// <param name="parent">Родительское подразделение. null - для получения корневых элементов</param>
    /// <returns></returns>
    IEnumerable<Firm> GetChildrenFirms(int? parent);

    IEnumerable<People> GetPeopleFromFirm(int firmId);
    IEnumerable<NsiItem> GetModelsByProducer(int pid);
    IEnumerable<NsiItem> GetProducers();

    People GetPeople(int id);
}

    public class Firm
    {
        public int? Id { get;  set; }
        public string Name { get;  set; }
        public bool HasChildren{get; set;}
    }

    public class People{
        public int Id{get;set;}
        public string Fio { get;  set; }
        public string EMail { get;  set; }
        public string Account { get;  set; }
        public string Post { get;  set; }
    }

    public class NsiItem
    {
        public string Name { get;  set; }
        public int Id { get;  set; }
    }
}
