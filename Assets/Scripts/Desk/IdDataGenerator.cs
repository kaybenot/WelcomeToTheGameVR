using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdDataGenerator {
    List<KeyValuePair<string, string>> namePairs = new List<KeyValuePair<string, string>> {
        new ("Sarah", "Sara"),
        new ("Brian", "Bryan"),
        new ("Catherine", "Katherine"),
        new ("Stephen", "Steven"),
        new ("Philip", "Phillip"),
        new ("Ann", "Anne"),
        new ("Geoffrey", "Jeffrey"),
        new ("Isabel", "Isabelle"),
        new ("Alan", "Allan"),
        new ("Elinor", "Eleanor"),
        new ("Michael", "Micheal"),
        new ("Aiden", "Aidan"),
        new ("Jayden", "Jaden"),
        new ("Eric", "Erik"),
        new ("Rebecca", "Rebekah"),
        new ("Aaron", "Aron"),
        new ("Holly", "Holli"),
        new ("Jon", "John"),
        new ("Gage", "Gauge"),
        new ("Sean", "Shawn"),
        new ("Hailey", "Haleigh"),
        new ("Lindsay", "Lindsey"),
        new ("Marc", "Mark"),
        new ("Mathew", "Matthew"),
        new ("Nathaniel", "Nathanial"),
        new ("Nicholas", "Nickolas"),
        new ("Collin", "Colin"),
        new ("Bradley", "Bradlee"),
        new ("Brittany", "Brittney"),
        new ("Kristen", "Kirsten"),
        new ("Teresa", "Theresa"),
        new ("Kurt", "Curt"),
        new ("Jerry", "Gerry"),
        new ("Leslie", "Lesley"),
        new ("Neal", "Neil"),
        new ("Alison", "Allison"),
        new ("Ricky", "Rickie"),
        new ("Julian", "Julien"),
        new ("Lori", "Laurie"),
        new ("Marsha", "Marcia"),
        new ("Marty", "Martie"),
        new ("Randal", "Randall"),
        new ("Rene", "Renae"),
        new ("Robbie", "Bobbie"),
        new ("Ronnie", "Ronny"),
        new ("Shari", "Sheri"),
        new ("Sherrie", "Sherry"),
        new ("Stacy", "Stacey"),
        new ("Terri", "Teri"),
        new ("Tony", "Toni"),
        new ("Tracy", "Tracey"),
        new ("Vicky", "Vicki"),
        new ("Wendy", "Wendi"),
        new ("Emilie", "Emily"),
        new ("Kellie", "Kelly"),
        new ("Darryl", "Darrel"),
        new ("Terrence", "Terrance"),
        new ("Jerald", "Gerald"),
        new ("Jessie", "Jesse"),
        new ("Christy", "Kristy"),
        new ("Benny", "Bennie"),
        new ("Vernon", "Vern"),
        new ("Daryl", "Darryl"),
        new ("Myles", "Miles"),
        new ("Donny", "Donnie"),
        new ("Raphael", "Rafael"),
        new ("Greg", "Graig"),
        new ("Lucas", "Lukas"),
        new ("Kasey", "Casey"),
        new ("Skylar", "Skyler"),
        new ("Greyson", "Grayson"),
        new ("Brayden", "Braeden"),
    };
    List<KeyValuePair<string, string>> surnamePairs = new List<KeyValuePair<string, string>> {
        new ("Johnson", "Johnston"),
        new ("Brown", "Browne"),
        new ("Jones", "Jonas"),
        new ("Rodriguez", "Rodriquez"),
        new ("Lopez", "Lopes"),
        new ("Gonzalez", "Gonzales"),
        new ("Anderson", "Andersen"),
        new ("Moore", "More"),
        new ("Harris", "Haris"),
        new ("Martin", "Marten"),
        new ("Thompson", "Tompson"),
        new ("Garcia", "Garcias"),
        new ("Martinez", "Martiniz"),
        new ("Robinson", "Robison"),
        new ("Clark", "Clarke"),
        new ("Rodriguez", "Rodriquez"),
        new ("Lewis", "Louis"),
        new ("Lee", "Li"),
        new ("Walker", "Walke"),
        new ("Hall", "Halle"),
        new ("Allen", "Allan"),
        new ("Young", "Younge"),
        new ("Hernandez", "Hernandes"),
        new ("King", "Kings"),
        new ("Wright", "Right"),
        new ("Lopez", "Lopes"),
        new ("Hill", "Hills"),
        new ("Scott", "Scot"),
        new ("Green", "Greene"),
        new ("Adams", "Addams"),
        new ("Gonzalez", "Gonzales"),
        new ("Nelson", "Nelsen"),
        new ("Mitchell", "Mitchel"),
        new ("Perez", "Perrez"),
        new ("Roberts", "Roberts"),
        new ("Turner", "Turnor"),
        new ("Phillips", "Philips"),
        new ("Campbell", "Cambell"),
        new ("Parker", "Parkes"),
        new ("Evans", "Evens"),
        new ("Edwards", "Edwardes"),
        new ("Collins", "Colins"),
        new ("Stewart", "Stuart"),
        new ("Sanchez", "Sanches"),
        new ("Morris", "Morriss"),
        new ("Rogers", "Rodgers"),
        new ("Reed", "Reid"),
        new ("Cook", "Cooke"),
        new ("Morgan", "Morgans"),
        new ("Bell", "Bel"),
        new ("Murphy", "Murphey"),
        new ("Bailey", "Bayley"),
        new ("Rivera", "Riviera"),
        new ("Cooper", "Cuper"),
        new ("Richardson", "Richards"),
        new ("Cox", "Cocks"),
        new ("Howard", "Howerd"),
        new ("Ward", "Warde"),
        new ("Torres", "Torrez"),
        new ("Peterson", "Petersen"),
        new ("Gray", "Grey"),
        new ("Ramirez", "Ramires"),
        new ("James", "Jaymes"),
        new ("Watson", "Wattson"),
        new ("Brooks", "Brookes"),
        new ("Kelly", "Kellie"),
        new ("Sanders", "Saunders"),
        new ("Price", "Pryce"),
        new ("Bennett", "Bennet"),
        new ("Wood", "Woods"),
        new ("Barnes", "Barns"),
        new ("Ross", "Ros"),
        new ("Henderson", "Hendeson"),
        new ("Coleman", "Colemen"),
        new ("Jenkins", "Jenkens"),
        new ("Perry", "Perrie"),
        new ("Powell", "Powel"),
        new ("Long", "Lang"),
        new ("Patterson", "Petersen"),
        new ("Hughes", "Hughs"),
        new ("Flores", "Floress"),
        new ("Washington", "Washingtone"),
        new ("Butler", "Buttler"),
        new ("Simmons", "Simons"),
        new ("Foster", "Forster")
    };

    public PairOfIds GeneratePairOfIds() {
        return Random.Range(0f, 1f) < 0.4f ? GenerateDifferentIds() : GenerateSameIds();
    }

    public PairOfIds GenerateSameIds() {
        var ret = new PairOfIds();
        var id = new IdData {
            age = Random.Range(18, 70),
            name = namePairs[Random.Range(0, namePairs.Count)].Key,
            surname = surnamePairs[Random.Range(0, surnamePairs.Count)].Key
        };
        ret.paperDocument = id;
        ret.websiteDocument = id;
        ret.areSame = true;
        return ret;
    }

    public PairOfIds GenerateDifferentIds() {
        var ret = new PairOfIds();
        var id = new IdData();
        var id2 = new IdData();
        id.age = id2.age = Random.Range(18, 70);
        var nameNr = Random.Range(0, namePairs.Count);
        id.name = namePairs[nameNr].Key;
        id2.name = namePairs[nameNr].Value;
        var surnameNr = Random.Range(0, surnamePairs.Count);
        id.surname = surnamePairs[surnameNr].Key;
        id2.surname = surnamePairs[surnameNr].Value;
        ret.paperDocument = id;
        ret.websiteDocument = id2;
        ret.areSame = false;
        return ret;
    }
}

public class PairOfIds {
    public bool areSame = false;
    public IdData paperDocument = new IdData();
    public IdData websiteDocument = new IdData();
}

public class IdData {
    public string name;
    public string surname;
    public int age;

    public string GetAsPaperText() {
        return $"{name} {surname}\nAge: {age}";
    }
    
    public string GetAsWebsiteText() {
        return $"Name: {name} \nSurname: {surname}\nAge: {age}";
    }
}