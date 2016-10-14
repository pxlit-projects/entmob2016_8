package be.pxl.spring.controller;

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
	
	@RequestMapping(method = RequestMethod.GET)
	public Session getSessionById(int id){		
		return sessionservice.findOne(id);
		
	}
	@RequestMapping(method = RequestMethod.POST)
	public void updateSession(Session s){
		sessionservice.save(s);
		
	}
}
