package be.pxl.spring.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;
import be.pxl.spring.repository.*;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class SessionRestController {

	@Autowired
	private SessionRepository repo;
	
	@RequestMapping(value="{id}", method = RequestMethod.GET)
	public Session getSessionById(@PathVariable("id") int id){		
		return repo.findOne(id);
		
	}
	

	
	@RequestMapping(method = RequestMethod.POST)
	public void updateSession(Session s){
		repo.save(s);
		
	}
}
