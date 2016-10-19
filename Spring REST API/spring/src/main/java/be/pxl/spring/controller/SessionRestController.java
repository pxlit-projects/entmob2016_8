package be.pxl.spring.controller;

import java.sql.Timestamp;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import be.pxl.spring.domain.Session;
import be.pxl.spring.repository.*;
import be.pxl.spring.service.SessionService;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class SessionRestController {

	@Autowired
	private SessionService sessionservice;
	
	@RequestMapping(method = RequestMethod.GET, value = "{id}")
	public Session getSessionById(@PathVariable("id") int id){		
		return sessionservice.findOne(id);
		
	}
	@RequestMapping(method = RequestMethod.POST, value="{s}")
	public void updateSession(@PathVariable("s") Session s){
		sessionservice.save(s);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "{userId}")
	public List<Session> getSessionsByUserId(int userId){
		return sessionservice.findByUserId(userId);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "{timeStamp}")
	public List<Session> getSessionsByDate(Timestamp timeStamp){
		return sessionservice.findByDate(timeStamp);
		
	}
	
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterStart/{timeStamp}")
	public List<Session> getSessionsByGreaterStartTime(Timestamp timeStamp){
		return sessionservice.findByGreaterStartTime(timeStamp);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserEnd/{timeStamp}")
	public List<Session> getSessionsByLesserEndTime(Timestamp timeStamp){
		return sessionservice.findByLesserEndTime(timeStamp);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterActual/{time}")
	public List<Session> getSessionsByGreaterActualTime(int time){
		return sessionservice.findByGreaterActualTime(time);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserActual/{time}")
	public List<Session> getSessionsByLesserActualTime(int time){
		return sessionservice.findByLesserActualTime(time);
		
	}
}
