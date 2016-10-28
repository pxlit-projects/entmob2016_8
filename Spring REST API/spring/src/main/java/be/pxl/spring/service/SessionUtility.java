package be.pxl.spring.service;

import java.util.Collection;


import java.util.Set;

import org.springframework.stereotype.Component;

import be.pxl.spring.domain.Session;

@Component
public class SessionUtility {
	
	public double AverageActual(Collection<Session> sessions){
		
		double sum = 0;
		for (Session session : sessions) {
			sum += session.getActualTime();
		}
		return sum/sessions.size();
	}
	
	public int MinimalActual(Collection<Session> sessions){
		int min = Integer.MAX_VALUE;
		for (Session session : sessions) {
			min = session.getActualTime() < min ? session.getActualTime(): min;
		}
		return min;
	}
	public int MaximalActual(Collection<Session> sessions){
		int max = Integer.MIN_VALUE;
		for (Session session : sessions) {
			max = session.getActualTime() > max ? session.getActualTime() : max;
		}
		return max;
	}

	public int TotalLength(Set<Session> sessions) {
		int sum = 0;
		int seconds;
		for (Session session : sessions) {
			seconds = (int) ((session.getEndTime().getTime() - session.getStartTime().getTime())/1000);
			sum += seconds;
		}
		return sum;
	}
	

}
