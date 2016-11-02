package be.pxl.spring.service;

import java.util.Collection;


import java.util.Set;

import org.springframework.stereotype.Component;

import be.pxl.spring.domain.Session;

@Component
public class SessionUtility {
	
	public double AverageActual(Collection<Session> sessions){
		if(!sessions.isEmpty()){
		double sum = 0;
		for (Session session : sessions) {
			sum += session.getActualTime();
		}
		return sum/sessions.size();
		}else
			return 0;
	}
	
	public int MinimalActual(Collection<Session> sessions){
		if(!sessions.isEmpty()){
		int min = Integer.MAX_VALUE;
		for (Session session : sessions) {
			min = session.getActualTime() < min ? session.getActualTime(): min;
		}
		return min;
		}else
			return 0;
	}
	public int MaximalActual(Collection<Session> sessions){
		if(!sessions.isEmpty()){
		int max = Integer.MIN_VALUE;
		for (Session session : sessions) {
			max = session.getActualTime() > max ? session.getActualTime() : max;
		}
		return max;
		}else
			return 0;
	}

	public int TotalLength(Collection<Session> sessions) {
		if(!sessions.isEmpty()){
		int sum = 0;
		int seconds;
		for (Session session : sessions) {
			seconds = (int) ((session.getEndTime().getTime() - session.getStartTime().getTime())/1000);
			sum += seconds;
		}
		return sum;
		}else
			return 0;
	}

	public double AverageLength(Collection<Session> sessions) {
		if(!sessions.isEmpty()){
		double sum = 0;
		for (Session session : sessions) {
			sum += ((session.getEndTime().getTime() - session.getStartTime().getTime())/1000);
		}
		return sum/sessions.size();
		}else
			return 0;
	}

	public int MinimalLength(Collection<Session> sessions) {
		if(!sessions.isEmpty()){
		int min = Integer.MAX_VALUE;
		int seconds;
		for (Session session : sessions) {
			seconds = (int) ((session.getEndTime().getTime() - session.getStartTime().getTime())/1000);
			min = seconds < min ? seconds: min;
		}
		return min;
		}else
			return 0;		
	}

	public int MaximalLength(Collection<Session> sessions) {
		if(!sessions.isEmpty()){
		int max = Integer.MIN_VALUE;
		int seconds;
		for (Session session : sessions) {
			seconds = (int) ((session.getEndTime().getTime() - session.getStartTime().getTime())/1000);
			max = seconds > max ? seconds : max;
		}
		return max;
		}else
			return 0;
	}
	

}
