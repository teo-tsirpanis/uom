package dai19090.oop2.surveillance.gui;

import dai19090.oop2.surveillance.core.*;
import dai19090.oop2.surveillance.graph.*;
import edu.uci.ics.jung.algorithms.layout.*;
import edu.uci.ics.jung.algorithms.shortestpath.*;
import edu.uci.ics.jung.graph.*;
import edu.uci.ics.jung.visualization.*;
import edu.uci.ics.jung.visualization.control.*;
import edu.uci.ics.jung.visualization.renderers.*;

import java.util.*;
import java.util.stream.*;
import java.awt.*;
import javax.swing.*;

@SuppressWarnings("serial")
public class SuspectWindow extends JFrame {
    private static final String APP_NAME = "SurveillanceNet v2";

    private JTextField suspectName = createReadOnlyTextField();
    private JTextField suspectNickname = createReadOnlyTextField();
    private DefaultListModel<String> suspectPhoneNumbers = new DefaultListModel<>();
    private JTextField smsNumberQuery = new JTextField();
    private DefaultListModel<String> suspiciousSMSs = new DefaultListModel<>();
    private JButton findSMSButton = new JButton("Find Suspicious SMS");
    private DefaultListModel<String> partners = new DefaultListModel<>();
    private DefaultListModel<String> suggestedPartners = new DefaultListModel<>();
    private JTextArea compatriots = new JTextArea();

    private final AbstractRegistry registry;
    private Suspect currentSuspect;

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

    private static void updateModel(DefaultListModel<String> m, Stream<String> data) {
        m.clear();
        m.addAll(data.collect(Collectors.toCollection(ArrayList::new)));
    }

    private Stream<String> getAllSuspiciousMessages(String number) {
        return currentSuspect
                .getNumbersUsed()
                .flatMap(n -> registry.getSuspiciousMessagesBetween(number, n))
                .map(SMS::getText);
    }

    public SuspectWindow(AbstractRegistry registry) {
        this.registry = registry;

        setSize(521, 521);
        setLocationRelativeTo(null);
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
        smsNumberQuery.setEnabled(false);
        smsNumberQuery.setText("Enter a phone number...");
        p.add(smsNumberQuery);
        p.add(new JList<>(suspiciousSMSs));
        findSMSButton.addActionListener(__ ->
                updateModel(suspiciousSMSs, getAllSuspiciousMessages(smsNumberQuery.getText())));
        findSMSButton.setEnabled(false);
        p.add(findSMSButton);
        cp.add(p);

        cp.add(createLabelledPanel("Partners:", new JList<>(partners)));
        cp.add(createLabelledPanel("Suggested Partners:", new JList<>(suggestedPartners)));
        compatriots.setEditable(false);
        cp.add(createLabelledPanel(null, compatriots));
        JButton returnToSearchScreen = new JButton("New Search");
        returnToSearchScreen.addActionListener(__ -> promptToFindSuspect());
        cp.add(createLabelledPanel(null, returnToSearchScreen));

        JButton visualizeNetwork = new JButton("Visualize network");
        visualizeNetwork.addActionListener(__ -> visualizeNetwork());
        cp.add(createLabelledPanel(null, visualizeNetwork));

        setContentPane(cp);
    }

    private void visualizeNetwork() {
        UndirectedGraph<Suspect, Object> graph = SuspectGraphing.createSuspectGraph(registry);
        JFrame window = new JFrame();
        window.setTitle("Suspects Network");
        window.setSize(747, 747);
        window.setLocationRelativeTo(null);
        JPanel cp = new JPanel();
        cp.setLayout(new BoxLayout(cp, BoxLayout.Y_AXIS));

        VisualizationViewer<Suspect, Object> vv = new VisualizationViewer<>(new CircleLayout<>(graph));
        vv.setGraphMouse(new DefaultModalGraphMouse<>());
        vv.getRenderContext().setVertexLabelRenderer(new DefaultVertexLabelRenderer(Color.BLACK));
        vv.getRenderContext().setVertexLabelTransformer(s -> s == null ? "" : s.getCodeName());
        cp.add(vv);

        JTextField diameterTextField = createReadOnlyTextField();
        diameterTextField.setText(String.format("Diameter = %.2f", DistanceStatistics.diameter(graph)));
        cp.add(diameterTextField);

        window.setContentPane(cp);
        window.setVisible(true);
    }

    public void displaySuspectInfo(Suspect s) {
        currentSuspect = s;
        suspectName.setText(s.getName());
        suspectNickname.setText(s.getCodeName());
        updateModel(suspectPhoneNumbers, s.getNumbersUsed());
        updateModel(partners, s.getPartners().map(Objects::toString));
        updateModel(suggestedPartners, s.getSuggestedPartners().map(Objects::toString));
        compatriots.setText("");
        compatriots.append(String.format("Suspects coming from %s\n", s.getCountry()));
        registry.getSuspectsFromCountry(s.getCountry())
                .forEach(x -> compatriots.append(String.format("%s\n", x.getName())));
        smsNumberQuery.setEnabled(true);
        findSMSButton.setEnabled(true);
    }

    public void promptToFindSuspect() {
        String name = JOptionPane.showInputDialog(this, "Please enter the name of the suspect fo find...",
                APP_NAME, JOptionPane.QUESTION_MESSAGE);
        if (name == null || name.isBlank())
            return;
        Optional<Suspect> s = registry.suspects().filter(x -> x.getName().equalsIgnoreCase(name)).findFirst();
        s.ifPresent(this::displaySuspectInfo);
        if (s.isPresent())
            displaySuspectInfo(s.get());
        else
            JOptionPane.showMessageDialog(this, String.format("Suspect %s was not found", name),
                    APP_NAME, JOptionPane.ERROR_MESSAGE);
    }
}
