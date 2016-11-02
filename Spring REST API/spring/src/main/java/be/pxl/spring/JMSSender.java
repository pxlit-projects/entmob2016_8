package be.pxl.spring;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

@Component
public class JMSSender {
	
	@Autowired
	private JmsTemplate jmsTemplate;
	
	public void log(String text){
		jmsTemplate.send("entmob", s -> s.createTextMessage(text));
	}
}
