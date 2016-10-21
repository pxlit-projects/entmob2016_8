package be.pxl.spring.service;

import java.util.Collection;


import org.springframework.stereotype.Component;

import be.pxl.spring.domain.Session;

@Component
public class AverageSessionLengthUtility {
	
	public double Calculate(Collection<Session> sessions){
		
		double sum = 0;
		for (Session session : sessions) {
			sum += session.getActualTime();
		}
		return sum/sessions.size();
	}
	

}
