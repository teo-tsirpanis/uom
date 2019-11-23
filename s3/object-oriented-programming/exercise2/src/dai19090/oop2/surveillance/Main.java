package dai19090.oop2.surveillance;

import java.util.ArrayList;

import dai19090.oop2.surveillance.core.*;

public class Main {

    public static void main(String[] args) {

        //Creation of suspect objects
        Suspect s1 = new Suspect("John Dow", "Sleepy Dog", "Spain", "Barcelona");
        s1.addNumber("00496955444444");
        s1.addNumber("00496955333333");

        Suspect s2 = new Suspect("Danny Rust", "Rusty Knife", "UK", "London");
        s2.addNumber("00446999888888");

        Suspect s3 = new Suspect("Bob Robson", "Frozen Bear", "Spain", "Oslo");
        s3.addNumber("00478484777777");
        s3.addNumber("00478484666666");
        s3.addNumber("00478484222222");

        //Creation of communication objects
        Communication[] comms = new Communication[14];

        comms[0] = new PhoneCall("00496955444444", "00478484777777", 15, 10, 2017, 127);
        comms[1] = new PhoneCall("00496955444444", "00478484777777", 16, 10, 2017, 240);
        comms[2] = new PhoneCall("00446999888888", "00496955333333", 17, 10, 2017, 52);
        comms[3] = new PhoneCall("00446999888888", "00478484777777", 18, 10, 2017, 180);
        comms[4] = new PhoneCall("00478484666666", "00496955333333", 19, 10, 2017, 305);
        comms[5] = new PhoneCall("00496955444444", "00478484222222", 20, 10, 2017, 247);
        comms[6] = new PhoneCall("00478484222222", "00496955333333", 21, 10, 2017, 32);

        comms[7] = new SMS("00496955444444", "00478484777777", 10, 10, 2017, "fancy a drink tonight?");
        comms[8] = new SMS("00496955333333", "00446999888888", 11, 10, 2017, "Nitro Bomb prepared");
        comms[9] = new SMS("00446999888888", "00496955444444", 12, 10, 2017, "flying to Berlin tomorrow");
        comms[10] = new SMS("00478484777777", "00446999888888", 13, 10, 2017, "No internet connection today");
        comms[11] = new SMS("00478484777777", "00446999888888", 14, 10, 2017, "Gun Received from Rusty Knife");
        comms[12] = new SMS("00478484777777", "00446999888888", 15, 10, 2017, "Metro Attack ready");
        comms[13] = new SMS("00478484666666", "00446999888888", 16, 10, 2017, "Explosives downtown have been placed");

        //Creation of Registry object
        AbstractRegistry registry = null;

        registry.addSuspect(s1);
        registry.addSuspect(s2);
        registry.addSuspect(s3);

        for (int i = 0; i < 14; i++)
            registry.addCommunication(comms[i]);


        //-------------TESTS----------------------
        //Test 1. Suspect With MostPartners
        Suspect topSuspect = registry.getSuspectWithMostPartners();
        System.out.println("Test1 – Suspect with most partners: " + topSuspect.getName() + ", " + topSuspect.getCodeName());

        //Test 2. Longest Phone Call Between
        PhoneCall longestCall = registry.getLongestPhoneCallBetween("00496955444444", "00478484777777");
        System.out.println("\nTest2 – Longest phone call between 2 numbers: ");
        longestCall.printInfo();

        //Test 3. get Suspicious Messages Between
        ArrayList<SMS> listOfMessages = registry.getMessagesBetween("00478484777777", "00446999888888");
        System.out.println("\nTest3 – Suspicious messages between 2 numbers: ");
        for (SMS sms : listOfMessages)
            sms.printInfo();

        //Test 4. check whether suspects are connected
        System.out.println("\nTest4 – Checking connection between 2 suspects: ");
        System.out.println(s1.isConnectedTo(s3));
        System.out.println(s3.isConnectedTo(s2));

        //Test 5. get List of common partners
        System.out.println("\nTest5 – List of common partners between 2 suspects: ");
        ArrayList<Suspect> commonSuspects = s1.getCommonPartners(s3);
        for (Suspect suspect : commonSuspects)
            System.out.println(suspect.getName() + ", " + suspect.getCodeName());

        //Test 6. print suspects originating from a country
        System.out.print("\nTest6 – ");
        registry.printSuspectsFromCountry("Spain");
    }

}
