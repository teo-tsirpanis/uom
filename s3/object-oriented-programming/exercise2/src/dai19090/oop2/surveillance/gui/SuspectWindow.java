package dai19090.oop2.surveillance.gui;

import dai19090.oop2.surveillance.core.*;

import java.util.*;
import java.util.stream.*;
import java.awt.*;
import javax.swing.*;

public class SuspectWindow extends JFrame {
    private JTextField suspectName = createReadOnlyTextField();
    private JTextField suspectNickname = createReadOnlyTextField();
    private DefaultListModel<String> suspectPhoneNumbers = new DefaultListModel<>();
    private JTextField smsNumberQuery = new JTextField();
    private DefaultListModel<String> suspiciousSMSs = new DefaultListModel<>();
    private JButton findSMSButton = new JButton("Find Suspicious SMS");
    private DefaultListModel<String> partners = new DefaultListModel<>();
    private DefaultListModel<String> suggestedPartners = new DefaultListModel<>();
    private JTextArea compatriots = new JTextArea();
    private JButton returnToSearchScreen = new JButton("Return to Search Screen");

    private final AbstractRegistry registry;

    private static JTextField createReadOnlyTextField() {
        JTextField tf = new JTextField();
        tf.setEditable(false);
        return tf;
    }

    private static JPanel createLabelledPanel(String label, Component c) {
        JPanel p = new JPanel();
        if (label != null) {
            p.add(new JLabel(label));
        }
        p.add(c);
        return p;
    }

    public SuspectWindow(AbstractRegistry registry) {
        this.registry = registry;

        setSize(521, 521);
        setTitle("Suspect Page");
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        JPanel cp = new JPanel();
        cp.setLayout(new BoxLayout(cp, BoxLayout.Y_AXIS));
        JPanel p = new JPanel();

        p.add(suspectName);
        p.add(suspectNickname);
        p.add(new JList<>(suspectPhoneNumbers));
        cp.add(p);

        p = new JPanel();
        smsNumberQuery.setText("Enter a phone number...");
        p.add(smsNumberQuery);
        p.add(new JList<>(suspiciousSMSs));
        p.add(findSMSButton);
        cp.add(p);

        cp.add(createLabelledPanel("Partners:", new JList<>(partners)));
        cp.add(createLabelledPanel("Suggested Partners:", new JList<>(suggestedPartners)));
        compatriots.setEditable(false);
        cp.add(createLabelledPanel(null, compatriots));
        cp.add(createLabelledPanel(null, returnToSearchScreen));

        setContentPane(cp);
    }

    private static void updateModel(DefaultListModel<String> m, Stream<String> data) {
        m.clear();
        m.addAll(data.collect(Collectors.toCollection(ArrayList::new)));
    }

    public void displaySuspectInfo(Suspect s) {
        suspectName.setText(s.getName());
        suspectNickname.setText(s.getCodeName());
        updateModel(suspectPhoneNumbers, s.getNumbersUsed());
        updateModel(partners, s.getPartners().map(Objects::toString));
        updateModel(suggestedPartners, s.getSuggestedPartners().map(Objects::toString));
        compatriots.setText("");
        compatriots.append(String.format("Suspects coming from %s\n", s.getCountry()));
        registry.suspects()
                .filter(x -> x.getCountry().equalsIgnoreCase(s.getCountry()))
                .forEach(x -> compatriots.append(String.format("%s\n", x.getName())));
    }
}
