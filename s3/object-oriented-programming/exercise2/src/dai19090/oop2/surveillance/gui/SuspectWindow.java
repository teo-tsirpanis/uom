package dai19090.oop2.surveillance.gui;

import javax.swing.*;
import java.awt.*;

public class SuspectWindow extends JFrame {
    private JTextField suspectName = createReadOnlyTextField();
    private JTextField suspectNickname = createReadOnlyTextField();
    private DefaultListModel<String> suspectPhoneNumbers = new DefaultListModel<>();
    private JTextField smsNumberQuery = new JTextField();
    private DefaultListModel<String> suspiciousSMSs = new DefaultListModel<>();
    private JButton findSMSButton = new JButton("Find SMS");
    private DefaultListModel<String> partners = new DefaultListModel<>();
    private DefaultListModel<String> suggestedPartners = new DefaultListModel<>();
    private JTextArea compatriots = new JTextArea();

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

    public SuspectWindow() {
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
        p.add(smsNumberQuery);
        p.add(new JList<>(suspiciousSMSs));
        p.add(findSMSButton);
        cp.add(p);

        cp.add(createLabelledPanel("Partners", new JList<>(partners)));
        cp.add(createLabelledPanel("Suggested Partners ----->", new JList<>(suggestedPartners)));
        cp.add(createLabelledPanel(null, compatriots));

        setContentPane(cp);
    }
}
